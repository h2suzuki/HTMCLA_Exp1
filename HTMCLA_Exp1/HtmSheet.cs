/*
    HTMCLA_Exp1
    Copyright (C) 2013  Hideaki Suzuki

    This file is part of HTMCLA_Exp1.
 
    HTMCLA_Exp1 is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;

namespace HTMCLA_Exp1
{
    #region HtmSynapse - the link between a column and input bits.

    struct HtmSynapse : IComparable<HtmSynapse>
    {
        const int defaultPermRange = 256;
        const int defaultConnectedPerm = 128;
        const int permRandomRange = 16;

        // Every 64 times (=256/4), synapses not reinforced gets its effective permenance cut by half.
        // Every 64 times, 0-perm synapses can reach the connectedPerm threshold by successive reinforcement.
        const int permInc = 4;

        readonly int idx;
        short permanence;
        short cache;        // The cache of the input bit value with this synapse.

        public HtmSynapse(int i, int r, int sinker)
        {
            idx = i;

            /*
             * The initial permanace will be +/- permRandomRange at random around defaultConnectedPerm.
             * Then,
             *   If sinker == 0,   permanence is defaultConnectedPerm + rnd % (2 * permRandomRange).
             *   If sinker == 100, permanence is defaultConnectedPerm +/- rnd % permRandomRange.
             *   If sinker == 200, permanence is defaultConnectedPerm - rnd % (2 * permRandomRange).
             */
            if ((r & 0x00010000) == 0)
                permanence = (short)((defaultConnectedPerm - 1) - (r % permRandomRange));
            else
                permanence = (short)((defaultConnectedPerm) + (r % permRandomRange));

            permanence += (short)(permRandomRange * (100 - sinker) / 100);

            cache = 0;
        }

        public int Index
        {
            get { return idx; }
        }
        public float Permanence(int threshold)
        {
            return 0.5F * permanence / threshold;
        }
        public int Input
        {
            get
            {
                return cache;
            }
            set
            {
                cache = (short)value;
            }
        }

        public int CompareTo(HtmSynapse s)
        {
            return s.permanence - this.permanence;
        }

        // Permanence related code.
        public bool IsConnected()
        {
            return defaultConnectedPerm <= permanence;
        }
        public bool IsConnected(int threshold)
        {
            return threshold <= permanence;
        }
        public void IncreasePerm()
        {
            permanence += permInc;
        }
        public bool ReinforcePerm(int threshold)    // Return the connectivity(bool) after reinforcing the perm.
        {
            if (cache > 0)
            {
                permanence += permInc;
                return true;    // always connected after positive reinforce.
            }
            return threshold <= permanence;
        }
        public void NormalizePerm()
        {
            permanence >>= 1;
            if (permanence >= defaultPermRange)
                permanence = defaultPermRange - 1;
        }

        // ConnectedPerm threshold related code.
        public static int InitialThreshold
        {
            get
            {
                return defaultConnectedPerm;
            }
        }
        public static int IncreaseThreshold(int threshold)
        {
            return threshold + permInc / 2;
        }
        public static bool NeedToNormalize(int threshold)
        {
            // After every 32nd time of IncreasePerm, i.e. defaultPermRange+32*permInc/2 >= permRange,
            // normalization will be necessary.
            return threshold >= defaultPermRange;
        }
    }

    #endregion

    #region HtmCell - a cell is contained by a column and represents the context of a column. (Not implemented yet)

    enum HtmCellState
    {
        Inactive = 0,
        Active = 1,
        Learning = 2,
    }

    struct HtmCell      // This is a "struct" type to avoid pointer dereferences in an array.
    {
        public HtmCellState state;
    }

    #endregion

    #region HtmColumn - a set of columns forms an HtmRegion

    enum HtmColumnState
    {
        Inactive = 0,
        Preactive = 1,
        Active = 2,
        Predicted = 3
    }

    struct HtmColumn
    {
        public HtmColumnState State;

        #region The column boost function

        // TODO: explore cheaper and better boosting algorithm.

        /* Column Boost:
         * 
         *   A column that is less often active than their neighbors receives boost for their intensity.
         *   Neighbors are considered through the inhibition process, because the inhibition is the
         *   process of "defining" the neighbors by some sense.
         *   
         *   The boosting factor at time n is determined as below.
         *   This is roughly the mean inhibition count between two activations.
         *   
         *       Bn = (Pn - An) / An
         *
         *   where Pn and An are the number of preactive and active state +1 since time=0 till time=n.
         *   
         *   So the initial values are P0 = 1, A0 = 1.  Because all active columns are chosen from preactive columns,
         *   if a columns has been preactive for 10 times and it has been active for 4 times at time = k,
         *   Pk = 11, Ak = 5.  Then,
         *   
         *       Bk = (Pk - Ak) / Ak = 6 / 5 = 1.2
         *
         *   By this definition,
         *     - If the column is always active (all-time winner), Pk = Ak.  Thus, Boosting Factor Bk = 0.
         *     - If the column is always inactive (all-time no overlap), Pk = Ak = 1.  Thus again Bn = 0.
         *     - If the column is always preactive (never won to become active), Pk = k + 1 and Ak = 1.  Bn = k.
         *
         *   The actual boosting value is Max(0, Bk - boostMinThreshold).
         */

        const int boostEvaluationDuration = 1024;   // unit: preactive count
        const int boostMinThreshold = 100;          // Columns with 1%(=1/100) or less active due to inhibition are eligible for boosting 

        public int PreactiveCount;
        public int ActiveCount;

        public static int MaxBoost
        {
            get
            {
                return boostEvaluationDuration - boostMinThreshold;
            }
        }
        public int Boost
        {
            get
            {
                // Calculate the boosting factor only when needed, so the total calculation amount is reduced.
                if (PreactiveCount > boostEvaluationDuration)
                {
                    PreactiveCount >>= 1;
                    ActiveCount >>= 1;
                }
                int boostingFactor = (PreactiveCount - ActiveCount) / (ActiveCount + 1);
                return Math.Max(0, boostingFactor - boostMinThreshold);
            }
        }

        #endregion

        #region The proximal dendrite segment of this column aka the bottom-up connect.

        public HtmSynapse[] Synapses;
        public int ConnectedPerm;
        public int ConnectedSynapseCount;
        public int Intensity;   // The total number of the active (= overlapped and connected) synapses.

        public void LearnThisPattern()
        {
            // Higher threshold automatically gives relative penalty to the inactive or disconnected synapses.
            int newThreshold = HtmSynapse.IncreaseThreshold(ConnectedPerm);

            // The connected active synapses need reinforcement.
            for (int i = ConnectedSynapseCount - 1; i >= 0; i--)
            {
                bool isConnected = Synapses[i].ReinforcePerm(newThreshold);

                if (!isConnected)
                {
                    if (--ConnectedSynapseCount > 0)    // Bring it to the end.
                    {
                        var t = Synapses[i];
                        Synapses[i] = Synapses[ConnectedSynapseCount];
                        Synapses[ConnectedSynapseCount] = t;
                    }
                }
            }
            ConnectedPerm = newThreshold;

            if (HtmSynapse.NeedToNormalize(newThreshold))
            {
                for (int j = 0; j < Synapses.Length; j++)
                    Synapses[j].NormalizePerm();

                ConnectedPerm = HtmSynapse.InitialThreshold;
            }
        }
        public void UnlearnPatterns()
        {
            if (ConnectedSynapseCount >= Synapses.Length)
                return;     // nothing to unlearn: this column already forgot everything.

            int newThreshold = HtmSynapse.IncreaseThreshold(ConnectedPerm);

            for (int i = 0; i < ConnectedSynapseCount; i++)
                Synapses[i].IncreasePerm();

            for (int i = ConnectedSynapseCount; i < Synapses.Length; i++)
            {
                Synapses[i].IncreasePerm();

                if (Synapses[i].IsConnected(newThreshold))
                {
                    if (++ConnectedSynapseCount < Synapses.Length)
                    {
                        var t = Synapses[i];
                        Synapses[i] = Synapses[ConnectedSynapseCount - 1];
                        Synapses[ConnectedSynapseCount - 1] = t;
                    }
                }
            }
            ConnectedPerm = newThreshold;

            if (HtmSynapse.NeedToNormalize(newThreshold))
            {
                for (int i = 0; i < Synapses.Length; i++)
                    Synapses[i].NormalizePerm();
                ConnectedPerm = HtmSynapse.InitialThreshold;
            }
        }

        #endregion

        // Find out how well this column overlaps the fanout area of the input bits.
        public void ComputeOverlap(int[] inputData, int minOverlap, bool doBoosting)
        {
            int overlap = 0;

            for (int i = 0; i < ConnectedSynapseCount; i++)
            {
                int k = inputData[Synapses[i].Index];
                Synapses[i].Input = k;
                overlap += k;
            }

            if (overlap <= minOverlap)
            {
                State = HtmColumnState.Inactive;
                Intensity = 0;
            }
            else
            {
                State = HtmColumnState.Preactive;
                Intensity = overlap;

                if (doBoosting)
                {
                    Intensity += Boost;
                    PreactiveCount++;   // This affects the next Boost value.
                }
            }
        }
    }

    #endregion

    #region HtmStats - a thread-safe array of statistics accessible using enum values.

    enum HtmStatsKey
    {
        Ticks,
        BucInitProgress,
        BucInitProgress100,

        SpOverlapTime,
        SpInhibitionTime,
        SpLearningTime,

        SpPreactiveCount,
        SpInhibitionRadius,
        SpInhibitionCount,
        SpUnlearnCount,

        LastKey // the anchor
    };

    class HtmStats
    {
        readonly long[] data;

        public HtmStats()
        {
            data = new long[(int)HtmStatsKey.LastKey + 1];     // +1 is only for safety.
        }

        public void Clear()
        {
            Array.Clear(data, 0, data.Length);
        }

        public long this[HtmStatsKey k]
        {
            get
            {
                return data[(int)k];
            }
            set
            {
                Interlocked.Exchange(ref data[(int)k], value);
            }
        }

        public void Inc(HtmStatsKey k)
        {
            Interlocked.Increment(ref data[(int)k]);
        }

        public void Add(HtmStatsKey k, int delta)
        {
            Interlocked.Add(ref data[(int)k], delta);
        }
    }

    #endregion

    #region HtmRegion - the memory unit to store spatial and temporal data in CLA

    class HtmRegion
    {
        #region Constants

        // Constants for value ranges;
        const int minSparsityRange = 1;
        const int maxSparsityRange = 99;
        const int minMinOverlapRange = 1;
        const int maxMinOverlapRange = 99;
        const int minUnlearningOverreactionRatioRange = 100;
        const int maxUnlearningOverreactionRatioRange = 200;

        // Constants for default values.
        const int defaultTargetActiveColumnRatio = 4;
        const int defaultMinOverlap = 2;
        const int defaultMinCoincidence = 75;
        const int defaultUnlearningOverreactionRatio = 110;

        #endregion

        protected readonly HtmColumn[] columns;         // These columns form the region.
        protected readonly HtmCell[][] cells;           // columns[i] contains cells[i][0..n].

        protected readonly List<int> inactiveColumns;   // TODO: these lists should be combined, which is probably
        protected readonly List<int> preactiveColumns;  // faster because it will cost less to move data around.
        protected readonly List<int> activeColumns;     //   Array := [0..inactive|preactive..|active..Length)

        protected readonly int totalColumnCount;
        protected readonly int totalCellCount;

        protected int targetActiveColumnRatio;
        protected int targetActiveColumnCount;

        protected int minOverlap;                       // for a proximal dendrite segment (bottom up connections)
        protected int minCoincidence;                   // for a distal dendrite segment (lateral connections)

        protected int unlearningOverreactionRatio;
        protected int unlearningOverreactionColumnCount;

        // for performance measurement & stats
        protected readonly System.Diagnostics.Stopwatch stopwatch;
        public readonly HtmStats Stats;

        public HtmRegion(int regionSize, int thickness)
        {
            if (regionSize < 1 || thickness < 1)
                throw new ArgumentOutOfRangeException();

            columns = new HtmColumn[regionSize];
            cells = new HtmCell[regionSize][];
            for (int i = 0; i < regionSize; i++)
                cells[i] = new HtmCell[thickness];

            inactiveColumns = new List<int>(regionSize);
            preactiveColumns = new List<int>(regionSize);
            activeColumns = new List<int>(regionSize);

            totalColumnCount = regionSize;
            totalCellCount = regionSize * thickness;

            targetActiveColumnRatio = defaultTargetActiveColumnRatio;
            targetActiveColumnCount = regionSize * defaultTargetActiveColumnRatio / 100;

            minOverlap = defaultMinOverlap;             // % active proximal synapses of a column
            minCoincidence = defaultMinCoincidence;     // % active distal synapses of a cell

            unlearningOverreactionRatio = defaultUnlearningOverreactionRatio;
            unlearningOverreactionColumnCount = targetActiveColumnCount * defaultUnlearningOverreactionRatio / 100;

            stopwatch = new System.Diagnostics.Stopwatch();
            Stats = new HtmStats();
        }

        public void ConnectTo(HtmRegion higherRegion)
        {
            throw new NotImplementedException();
        }

        public static int RefreshRegions()
        {
            throw new NotImplementedException();
        }

        #region The interface for GUI

        public int TargetSparsity
        {
            get
            {
                return targetActiveColumnRatio;
            }
            set
            {
                if (value < minSparsityRange || maxSparsityRange < value)
                    throw new ArgumentOutOfRangeException();
                targetActiveColumnRatio = value;
                targetActiveColumnCount = totalColumnCount * value / 100;
                unlearningOverreactionColumnCount = Math.Min(targetActiveColumnCount * unlearningOverreactionRatio / 100, totalColumnCount);
            }
        }
        public virtual int MinOverlap
        {
            get
            {
                return minOverlap;
            }
            set
            {
                if (value < minMinOverlapRange || maxMinOverlapRange < value)
                    throw new ArgumentOutOfRangeException();
                minOverlap = value;
            }
        }
        public int MinCoincidence
        {
            get
            {
                return minCoincidence;
            }
            set
            {
                if (value < 1 || 99 < value)
                    throw new ArgumentOutOfRangeException();
                minCoincidence = value;
            }
        }
        public int UnlearningOverreactionRatio
        {
            get
            {
                return unlearningOverreactionRatio;
            }
            set
            {
                if (value < minUnlearningOverreactionRatioRange || maxUnlearningOverreactionRatioRange < value)
                    throw new ArgumentOutOfRangeException();
                unlearningOverreactionRatio = value;
                unlearningOverreactionColumnCount = Math.Min(targetActiveColumnCount * value / 100, totalColumnCount);
                // System.Console.WriteLine("Unlearn: {0}%, {1} columns", unlearningOverreactionRatio, unlearningOverreactionColumnCount);
            }
        }
        public int TotalColumnCount
        {
            get { return totalColumnCount; }
        }
        public int ActiveColumnCount
        {
            get { return activeColumns.Count; }
        }
        public int PreactiveColumnCount
        {
            get { return preactiveColumns.Count; }
        }

        public HtmColumnState GetColumnState(int i)
        {
            return columns[i].State;
        }
        public int GetColumnPreactiveStateCount(int i)
        {
            return columns[i].PreactiveCount;
        }
        public int GetColumnActiveStateCount(int i)
        {
            return columns[i].ActiveCount;
        }
        public int GetColumnBoost(int i)
        {
            return columns[i].Boost;
        }
        public int GetConnectedSynapseCount(int i)
        {
            return columns[i].ConnectedSynapseCount;
        }
        public int GetConnectedPerm(int i)
        {
            return columns[i].ConnectedPerm;
        }
        public int GetIntensity(int i)
        {
            return columns[i].Intensity;
        }

        public float GetStatsMilliseconds(HtmStatsKey k)
        {
            return 1000.0F * Stats[k] / System.Diagnostics.Stopwatch.Frequency;
        }
        public int GetStatsCount(HtmStatsKey k)
        {
            return (int)Stats[k];
        }

        #endregion
    }

    class HtmRegionFor2D : HtmRegion
    {
        #region Constants

        const float defaultFanoutOverlapFactor  = 1.5F;     // 150% overlaped fanoutRadius with adjacent columns.
        const int defaultPermSinker             = 66;       // This brings roughly 50% of synapses to be connected.
        const int defaultInhibitionPenaltyRatio = 8;

        const int pixelPickerPatterns = 25;

        const int maxInhibitionRadius = 10;     // This depends on the minimum target sparsity: sqrt(1/minTargetSparstiy)

        #endregion

        public readonly int Width;
        public readonly int Height;
        public readonly int Thickness;

        readonly int[] neighborCountByDistance;     // neighborCountByDistance[d] gives the number of columns within distance d.
        readonly int[][] neighbors;                 // neighbors[i][] stores the neighbor columns of column[i].

        int localInhibitionPenaltyRatio;
        int localInhibitionPenalty;

        LinkedList<int>[] labelTables;

        // for GUI
        public bool DoLocalInhibition;  // Flags to control the optional behavior of write()
        public bool DoLearning;
        public bool DoBoosting;
        public bool DoUnlearning;
        int maxBottomUpIntensity;
        int minBottomUpIntensity;

        public HtmRegionFor2D(int width, int height, int thickness)
            : base(width * height, thickness)
        {
            if (width < 1 || height < 1 || thickness < 1)
                throw new ArgumentOutOfRangeException();

            Width = width;
            Height = height;
            Thickness = thickness;

            // Because maxInhibitionRadius is known, neighbors can be setup statically (instead of computing on the fly)
            neighbors = new int[columns.Length][];
            neighborCountByDistance = new int[maxInhibitionRadius + 1];
            setupNeighborhood(width, height);

            localInhibitionPenaltyRatio = defaultInhibitionPenaltyRatio;
            localInhibitionPenalty = 0;

            labelTables = new LinkedList<int>[columns.Length];
            for (int i = 0; i < columns.Length; i++)
                labelTables[i] = new LinkedList<int>();

            DoLocalInhibition = false;
            DoLearning = false;
            DoBoosting = false;
            DoUnlearning = false;
            maxBottomUpIntensity = 0;       // Exclusive
            minBottomUpIntensity = 0;       // Inclusive
        }

        void setupNeighborhood(int width, int height)
        {
            /*
             * Setup the neighborhood relations in this region
             * 
             *   The largest inhibition area can be given by the following equation.
             *
             *      MaxInhibitionRadius = sqrt(Max # of preactive columns / # of active columns)
             *                          = sqrt(N / (N * TargetSparsity))
             *                          = sqrt(1 / TargetSparsity)
             *
             *   Hence, by defining the lowest density of TargetSparsity as 1%,
             *   we can obtain the largest possible radius.
             *
             *      MaxInhibitionRadius = sqrt(1 / 0.01) = sqrt(100) = 10
             *      The number of columns within the area is less than (2*10+1)^2 = 441 columns
             *
             *   This is "independent" from the size of region.
             */

            // Setup the template of neighborhood relations.
            var buckets = new List<Point>[maxInhibitionRadius + 1];

            for (int i = 1; i < maxInhibitionRadius + 1; i++)
                buckets[i] = new List<Point>();

            for (int y = -maxInhibitionRadius; y <= maxInhibitionRadius; y++)
            {
                for (int x = -maxInhibitionRadius; x <= maxInhibitionRadius; x++)
                {
                    int distance = (int)(Math.Round(Math.Sqrt(x * x + y * y)));

                    if (0 < distance && distance <= maxInhibitionRadius)
                        buckets[distance].Add(new Point(x, y));
                }
            }

            // Calculate the number of columns within a given distance.
            var sortedNeighbors = new List<Point>((2 * maxInhibitionRadius + 1) * (2 * maxInhibitionRadius + 1));

            neighborCountByDistance[0] = 0;
            for (int i = 1; i < maxInhibitionRadius + 1; i++)
            {
                sortedNeighbors.AddRange(buckets[i]);
                neighborCountByDistance[i] = sortedNeighbors.Count;
                buckets[i] = null;
            }

            // Translate sortedNeighbors to the location based on a column's center.
            for (int i = 0; i < columns.Length; i++)
            {
                neighbors[i] = new int[sortedNeighbors.Count];

                int xc = i % width;
                int yc = i / width;

                for (int j = 0; j < sortedNeighbors.Count; j++)
                {
                    int x = (xc + sortedNeighbors[j].X + width) % width;
                    int y = (yc + sortedNeighbors[j].Y + height) % height;
                    neighbors[i][j] = y * width + x;
                }
            }

            System.Console.WriteLine("SetupNeigh: neighbors[{0}][{1}] is ready for 2D",
                columns.Length, sortedNeighbors.Count);
        }

        public void InitializeBucSynapses(int imageWidth, int imageHeight, int fanoutRadius = -1, int nSynapses = 256, int permSinker = -1)
        {
            if (imageWidth < Width || imageHeight < Height)
                throw new System.ArgumentOutOfRangeException();

            Stats[HtmStatsKey.Ticks] = 0;

            int delta = Math.Min(imageWidth / Width, imageHeight / Height);

            if (fanoutRadius < 0)
                fanoutRadius = (int)((defaultFanoutOverlapFactor + 0.5F) * delta);

            System.Console.WriteLine("InitBUC: delta = {0}  fanoutRadius = {1}", delta, fanoutRadius);

            int maxSynapses = (2 * fanoutRadius + 1) * (2 * fanoutRadius + 1);

            if (nSynapses < 1 || maxSynapses < nSynapses)
                nSynapses = maxSynapses;                     // Out of range; adjusting

            maxBottomUpIntensity = nSynapses;
            minBottomUpIntensity = nSynapses * minOverlap / 100;

            System.Console.WriteLine("InitBUC: nSynapses = {0} (maxSynapses = {1})", nSynapses, maxSynapses);

            if (permSinker < 0)
                permSinker = defaultPermSinker;

            System.Console.WriteLine("InitBUC: permSinker = {0}", permSinker);

            localInhibitionPenalty = nSynapses * localInhibitionPenaltyRatio / 100;

            System.Console.WriteLine("InitBUC: inhibition penalty = {0} ({1}%)", localInhibitionPenalty, localInhibitionPenaltyRatio);

            // Clear the label tables.
            for (int i = 0; i < columns.Length; i++)
                labelTables[i].Clear();

            System.Console.WriteLine("InitBUC: the label tables are cleared");

            // Reset the random generator.
            var rnd = new jp.takel.PseudoRandom.MersenneTwister(46692016);

            System.Console.WriteLine("InitBUC: random generator is reset");

            // For the reporting purpose to GUI
            Stats[HtmStatsKey.BucInitProgress100] = 10 * maxSynapses * pixelPickerPatterns + 2 * nSynapses * columns.Length;
            Stats[HtmStatsKey.BucInitProgress] = 0;

            // Setup pixelPickers[]
            var pixelPickers = new int[pixelPickerPatterns][];
            for (int i = 0; i < pixelPickerPatterns; i++)
            {
                var p = new int[maxSynapses];

                for (int j = 0; j < maxSynapses; j++)
                    p[j] = j;

                pixelPickers[i] = p.OrderBy(x => rnd.NextUInt()).ToArray();

                Stats.Add(HtmStatsKey.BucInitProgress, 10 * maxSynapses);
            }

            // Setup the proximal synapses for all columns.
            for (int i = 0; i < columns.Length; i++)
            {
                // The center of the fanout area of the size [2*fanoutRadias+1, 2*fanoutRadias+1]
                int xc = (delta / 2) + (i % Width) * delta;
                int yc = (delta / 2) + (i / Width) * delta;

                var pattern = pixelPickers[rnd.NextUInt() % pixelPickers.Length];

                var newSynapses = new HtmSynapse[nSynapses];
                for (int j = 0; j < nSynapses; j++)
                {
                    // The pixel of the input image where this synapse lands.
                    int x = (xc - fanoutRadius) + pattern[j] % (2 * fanoutRadius + 1);
                    int y = (yc - fanoutRadius) + pattern[j] / (2 * fanoutRadius + 1);

                    // Permanence is biased by the distance from the center of this fanout area.
                    double distanceFromCenter = Math.Sqrt((x - xc) * (x - xc) + (y - yc) * (y - yc));

                    // Wrap around the edges of the region.
                    x = (x + imageWidth) % imageWidth;
                    y = (y + imageHeight) % imageHeight;

                    newSynapses[j] = new HtmSynapse(
                            y * imageWidth + x,     // Convert to the linear index for the bitmap data.
                            (int)(rnd.NextUInt()),
                            (int)(2 * distanceFromCenter / (fanoutRadius + 1) * permSinker));
                }
                Array.Sort(newSynapses);
                int n = Array.FindIndex(newSynapses, s => !s.IsConnected());
                if (n < 0) n = nSynapses;

                columns[i] = new HtmColumn()
                    {
                        Synapses = newSynapses,
                        ConnectedSynapseCount = n,
                        ConnectedPerm = HtmSynapse.InitialThreshold,
                    };

                Stats.Add(HtmStatsKey.BucInitProgress, 2 * nSynapses);
            }
        }

        #region The interface for GUI

        public override int MinOverlap
        {
            get
            {
                return base.MinOverlap;
            }
            set
            {
                base.MinOverlap = value;
                minBottomUpIntensity = maxBottomUpIntensity * value / 100;
            }
        }
        public int MaxBottomUpIntensity
        {
            get
            {
                return maxBottomUpIntensity;
            }
        }
        public int MinBottomUpIntensity
        {
            get
            {
                return minBottomUpIntensity;
            }
        }
        public int LocalInhibitionPenaltyRatio
        {
            get
            {
                return localInhibitionPenaltyRatio;
            }
            set
            {
                if (value<1 || 99<value)
                    throw new ArgumentOutOfRangeException();
                localInhibitionPenaltyRatio = value;
                localInhibitionPenalty = maxBottomUpIntensity * value / 100;
            }
        }

        public HtmColumnState GetColumnState(int x, int y)
        {
            return GetColumnState(y * Width + x);
        }
        public int GetColumnPreactiveStateCount(int x, int y)
        {
            return GetColumnPreactiveStateCount(y * Width + x);
        }
        public int GetColumnActiveStateCount(int x, int y)
        {
            return GetColumnActiveStateCount(y * Width + x);
        }
        public int GetColumnBoost(int x, int y)
        {
            return GetColumnBoost(y * Width + x);
        }
        public int GetConnectedSynapseCount(int x, int y)
        {
            return GetConnectedSynapseCount(y * Width + x);
        }
        public int GetConnectedPerm(int x, int y)
        {
            return GetConnectedPerm(y * Width + x);
        }
        public int GetIntensity(int x, int y)
        {
            return GetIntensity(y * Width + x);
        }

        public int BucInitProgress
        {
            get
            {
                return (int)(100 * Stats[HtmStatsKey.BucInitProgress] / (Stats[HtmStatsKey.BucInitProgress100] + 1));
            }
        }

        public void GetConnectedSynapseCount(out int min, out int ave, out int max)
        {
            min = maxBottomUpIntensity;
            max = 0;

            int sum = 0;
            foreach (var c in columns)
            {
                sum += c.ConnectedSynapseCount;
                min = Math.Min(min, c.ConnectedSynapseCount);
                max = Math.Max(max, c.ConnectedSynapseCount);
            }
            ave = sum / columns.Length;
        }
        public void GetLabelTableCount(out int min, out int ave, out int max)
        {
            min = int.MaxValue;
            max = 0;

            int sum = 0;
            foreach (var t in labelTables)
            {
                sum += t.Count;
                min = Math.Min(min, t.Count);
                max = Math.Max(max, t.Count);
            }
            ave = sum / labelTables.Length;
        }

        void drawColumnSynapseSpray(Graphics g, int imgWidth, int colX, int colY, Color disconn, Color inactive, Color active)
        {
            int i = colY * Width + colX;
            int threshold = columns[i].ConnectedPerm;

            foreach (var s in columns[i].Synapses)
            {
                Color c;

                if (!s.IsConnected(threshold))
                    c = disconn;
                else
                    c = s.Input > 0 ? active : inactive;

                using (var brush = new SolidBrush(c))
                    g.FillRectangle(brush, s.Index % imgWidth, s.Index / imgWidth, 1, 1);
            }
        }
        public void DrawColumnSynapseSpray(Graphics g, int imgWidth, int colX, int colY)
        {
            drawColumnSynapseSpray(g, imgWidth, colX, colY, Color.Gray, Color.Green, Color.Yellow);
        }
        public void DrawColumnSynapseSpraySpecific(Graphics g, int imgWidth, int colX, int colY)
        {
            if (columns[colY * Width + colX].State != HtmColumnState.Active)
                drawColumnSynapseSpray(g, imgWidth, colX, colY, Color.Gray, Color.Green, Color.Yellow);
            else
                drawColumnSynapseSpray(g, imgWidth, colX, colY, Color.Blue, Color.Green, Color.Red);
        }
        public void DrawBucPermSpectram(Graphics g, int imgWidth, int colX, int colY)
        {
            int i = colY * Width + colX;
            var s = columns[i].Synapses;

            float x, y;

            x = 5.0F + 128.0F * MinBottomUpIntensity / s.Length;
            g.DrawLine(Pens.Black, x, 10.0F, x, 60.0F);

            x = 5.0F + 128.0F * columns[i].ConnectedSynapseCount / s.Length;
            g.DrawLine(Pens.Black, x, 10.0F, x, 60.0F);

            g.DrawRectangle(Pens.Black, 5.0F, 10.0F, 128.0F, 50.0F);

            int threshold = columns[i].ConnectedPerm;
            for (var j = 0; j < s.Length; j++)
            {
                x = 5.0F + 128.0F * j / s.Length;
                y = 60.0F - 50.0F * s[j].Permanence(threshold);

                Color c;

                if (!s[j].IsConnected(threshold))
                    c = Color.Blue;
                else if (s[j].Input > 0)
                    c = Color.Red;
                else
                    c = Color.Green;

                using (var pen = new Pen(c))
                    g.DrawLine(pen, x, 35.0F, x, y);
            }

            g.DrawLine(Pens.Black, 5.0F, 35.0F, 5.0F + 128.0F, 35.0F);
        }

        #endregion

        #region Utility functions
        
        static void swap(List<int> data, int idx1, int idx2)
        {
            int t = data[idx1];
            data[idx1] = data[idx2];
            data[idx2] = t;
        }

        static void bringKthLargest2Tail(List<int> data, int tail, Func<int, int> key)
        {
#if USE_BUILTIN_SORT
            data.Sort((i, j) => (columns[i].Intensity - columns[j].Intensity));
#else
            // This is a variant of std::nth_elenemt, aka. quick select algorithm.

            int l = 0, r = data.Count - 1;

            while (l < r)
            {
                if (l + 1 == r) // only two elements are there
                {
                    if (key(data[l]) > key(data[r]))
                        swap(data, l, r);
                    return;
                }

                // the simple pivot selection "median of three" + bring the median to the right.
                int m = (r + l + 1) / 2;
                if (key(data[l]) > key(data[r]))
                    swap(data, l, r);
                if (key(data[l]) > key(data[m]))
                    swap(data, l, m);
                if (key(data[r]) > key(data[m]))
                    swap(data, r, m);

                // partitioning
                int pivot = key(data[r]);
                int nextStore = l + 1;
                for (int i = l + 1; i < r; i++)
                {
                    if (key(data[i]) < pivot)
                    {
                        if (i != nextStore) swap(data, i, nextStore);
                        nextStore++;
                    }
                }
                swap(data, nextStore, r);   // now data[nextStore] has the median.

                if (nextStore == tail)
                    return;
                if (tail < nextStore)
                    r = nextStore - 1;
                else
                    l = nextStore + 1;
            }
#endif
        }

        #endregion

        #region Basic operations

        public int Write(int[] inputBitmap, int label)
        {
            inactiveColumns.Clear();
            preactiveColumns.Clear();
            activeColumns.Clear();

            stopwatch.Reset();

            if (targetActiveColumnCount == 0)   // sanity check.
                return 0;

            Stats.Inc(HtmStatsKey.Ticks);

            /* =================================
             * =        Spacial Pooling        =
             * ================================= */

            /*
             * Phase 1: Overlap
             * 
             *   For each column, count the number of connected synapses that overlap the inputBitmap bit 1.
             *   If the number is larger than MinBottomUpIntensity, mark it as preactive.
             *   
             *   The amount of computation:
             *       O(the number of the columns * average(the number of connected proximal synapses))
             */

            stopwatch.Start();

            for (int i = 0; i < columns.Length; i++)
            {
                columns[i].ComputeOverlap(inputBitmap, minBottomUpIntensity, DoBoosting);

                if (columns[i].State == HtmColumnState.Preactive)
                    preactiveColumns.Add(i);
                else
                    inactiveColumns.Add(i);
            }

            stopwatch.Stop();

            Stats[HtmStatsKey.SpOverlapTime] = stopwatch.ElapsedTicks;
            Stats[HtmStatsKey.SpPreactiveCount] = preactiveColumns.Count;

            /*
             * Phase 2: Inhibition
             * 
             *   Inhibition forces the sparcity of SDR in the region.  Three cases are handled here.
             *   
             *   Case   Description                         The amount of computation
             *   ------------------------------------------------------------------------------
             *     1    Too few preactive columns found.    O(P) where P < A
             *     2    Only global inhibition is enabled.  O(P + A)
             *     3    Local inhibition is needed.         O((P + A)*(P - A + 1) + R*A)
             *      
             *   Where
             *       P is the number of preactive columns.
             *       A is the number of active columns.
             *       R is the size of inhibition area.
             */

            Stats[HtmStatsKey.SpInhibitionCount] = 0;
            Stats[HtmStatsKey.SpInhibitionRadius] = 0;

            stopwatch.Restart();

            // Pre-condition; nothing to inhibit.
            if (preactiveColumns.Count == 0)
                goto SpatialPoolerInhibitionDone;

            // Case 1: Too less preactive columns; no need of inhibition.
            if (preactiveColumns.Count <= targetActiveColumnCount)
            {
                // Move the items from preactiveColumns to activeColumns.
                activeColumns.AddRange(preactiveColumns);
                preactiveColumns.Clear();

                // Update the column state
                foreach (int i in activeColumns)
                {
                    columns[i].State = HtmColumnState.Active;
                    if (DoLearning)
                        columns[i].ActiveCount++;    // This affects the next columns boost
                }

                goto SpatialPoolerInhibitionDone;
            }

            // Case 2: Global inhibition.
            if (!DoLocalInhibition)
            {
                int tail = preactiveColumns.Count - targetActiveColumnCount;
                bringKthLargest2Tail(preactiveColumns, tail, (i) => columns[i].Intensity);

                // Move the last A items from preactiveColumns to activeColumns.
                activeColumns.AddRange(preactiveColumns.Skip(tail));
                preactiveColumns.RemoveRange(tail, targetActiveColumnCount);    // This involves Array.clear

                // Update the column state
                foreach (int i in activeColumns)
                {
                    columns[i].State = HtmColumnState.Active;
                    if (DoLearning)
                        columns[i].ActiveCount++;    // This affects the next columns boost
                }

                Stats[HtmStatsKey.SpInhibitionCount] = preactiveColumns.Count;
                goto SpatialPoolerInhibitionDone;
            }

#if ! UsePenaltyBasedLocalInhibition
            // Case 3: Local inhibition.

            // This is the double size of the target radius and always bigger than 0.
            int inhibitionRadius = (int)Math.Sqrt(preactiveColumns.Count / targetActiveColumnCount);

            for (int i = 0; i < targetActiveColumnCount; i++)
            {
                int maxIntensity = columns[preactiveColumns[0]].Intensity;
                int idxAtMax = 0;

                // Scan the active columns and find the one with the highest intensity.
                for (int j = 1; j < preactiveColumns.Count; j++)
                {
                    int intensity = columns[preactiveColumns[j]].Intensity;

                    if (maxIntensity < intensity)
                    {
                        maxIntensity = intensity;
                        idxAtMax = j;
                    }
                }

                // Mark it as active
                int chosen = preactiveColumns[idxAtMax];
                preactiveColumns[idxAtMax] = preactiveColumns[preactiveColumns.Count - 1];
                preactiveColumns.RemoveAt(preactiveColumns.Count - 1);

                columns[chosen].State = HtmColumnState.Active;
                activeColumns.Add(chosen);
                if (DoLearning)
                    columns[chosen].ActiveCount++;    // This affects the next column boost

                // Put penalty to its neighbor columns.
                foreach (int k in neighbors[chosen].Take(neighborCountByDistance[inhibitionRadius]))
                {
                    if (columns[k].State == HtmColumnState.Preactive)
                        columns[k].Intensity -= localInhibitionPenalty;
                }
            }
#else
            // Case 3: Local inhibition (the white paper version)

            int inhibitionRadius = (int)Math.Sqrt(preactiveColumns.Count / targetActiveColumnCount);
            int desiredLocalActivity = neighborColumnCountByDistance[inhibitionRadius] * 33 / 100;

            var candidates = new List<int>(neighborColumnCountByDistance[inhibitionRadius]);

            for (int i = 0; i < columns.Length; i++)
            {
                candidates.AddRange(neighbors[i].Take(neighborColumnCountByDistance[inhibitionRadius]));

                int tail = candidates.Count - desiredLocalActivity;
                bringKthLargest2Tail(candidates, tail, (k) => columns[k].Intensity);

                if (columns[candidates[tail]].Intensity < columns[i].Intensity)
                {
                    columns[i].State = HtmColumnState.Active;
                    activeColumns.Add(i);
                    if (DoLearning)
                        columns[i].ActiveCount++;    // This affects the next column boost

                    preactiveColumns.Remove(i);
                }
                candidates.Clear();
            }
#endif
            Stats[HtmStatsKey.SpInhibitionCount] = preactiveColumns.Count;
            Stats[HtmStatsKey.SpInhibitionRadius] = inhibitionRadius;

        SpatialPoolerInhibitionDone:

            stopwatch.Stop();
            Stats[HtmStatsKey.SpInhibitionTime] = stopwatch.ElapsedTicks;

            /*
             * Phase 3: Learning
             * 
             *   Spatial pooler learns the input patterns by reinforcing synapses, which makes each column 
             *   to be adept with specific input patterns.  Learning includes unlearning, too.  If we don't
             *   see an input pattern for long time, the columns will unlearn (i.e. forget) the pattern
             *   and go for re-capturing new patterns as needed.
             * 
             *   The amount of computation:
             *       Learning:      O(A*(Sc + P*Sa/64))
             *       Unlearning:    O(1)                if the target sparsity is achieved
             *                      O(I*Sa + Scn)       if I <= U
             *                      O(I + U*Sa + Scn)   if I > U
             *       
             *   Where
             *       A is the number of active columns.
             *       I is the number of inactive columns.
             *       U is the number of unlearning columns.  --> This is the major addition to the algorithm in WP.
             *       Sc is the average number of the connected proximal synapses of a column.
             *       Sa is the number of the potential synapses of a column.
             *       Scn is the average number of the disconnected proximal synapses that become connected by unlearning.
             *       P is the probability of one column being active (A / the number of columns in the receptive field).
             *   
             *  For the magic number 64, see HtmSynapse; every 64 times, we need to normalize permanences.
             */

            Stats[HtmStatsKey.SpUnlearnCount] = 0;

            stopwatch.Restart();

            if (DoLearning)
            {
                foreach (var i in activeColumns)
                    columns[i].LearnThisPattern();
            }

            if (DoUnlearning)
            {
                if (activeColumns.Count < targetActiveColumnCount)
                {
                    // How many columns do we need to unlearn?
                    int n = unlearningOverreactionColumnCount - activeColumns.Count;

                    if (n < inactiveColumns.Count)
                    {
                        int tail = inactiveColumns.Count - n;
                        bringKthLargest2Tail(inactiveColumns, tail, (i) => -columns[i].ConnectedSynapseCount);

                        foreach (int i in inactiveColumns.Skip(tail))
                            columns[i].UnlearnPatterns();

                        Stats[HtmStatsKey.SpUnlearnCount] = n;
                    }
                    else
                    {
                        foreach (int i in inactiveColumns)
                            columns[i].UnlearnPatterns();

                        Stats[HtmStatsKey.SpUnlearnCount] = inactiveColumns.Count;
                    }
                }
            }
            
            stopwatch.Stop();
            Stats[HtmStatsKey.SpLearningTime] = stopwatch.ElapsedTicks;

            /*
             * Phase 4: Labeling active columns (extra)
             *
             *   This phase binds the given label to the computed SDR so that we can classify the input
             *   patterns by labels later; the functionality is provided by read().
             *   This additional phase is not related to the white paper.
             */

            if (DoLearning)
            {
                foreach (int i in activeColumns)
                {
                    var node = labelTables[i].Find(label);

                    if (node != null)
                    {
                        labelTables[i].Remove(node);
                        labelTables[i].AddFirst(node);
                    }
                    else
                    {
                        labelTables[i].AddFirst(label);
                    }
                }
            }

            /* =================================
             * =       Temporal Pooling        =
             * ================================= */

            // To be implemented.

            return activeColumns.Count;
        }

        public void Read(List<KeyValuePair<int,int>> labelHistogram)
        {
            var dict = new SortedDictionary<int, int>();

            foreach (int i in activeColumns)
                foreach (int label in labelTables[i])
                    if (dict.ContainsKey(label))
                        dict[label]++;
                    else
                        dict[label] = 1;

            foreach (var kvp in dict)
                labelHistogram.Add(new KeyValuePair<int,int>(kvp.Value,kvp.Key));

            labelHistogram.Sort((a, b) => b.Key - a.Key);
        }

        public void ReadPrediction(out string[] labels, int[] confidence)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    #endregion

}
