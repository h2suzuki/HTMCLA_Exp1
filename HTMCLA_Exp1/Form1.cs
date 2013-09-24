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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMCLA_Exp1
{
    public partial class Form1 : Form
    {
        #region Form constructor

        string inputWord;
        readonly Int32[] rawBitmap;   // The input bits for the spatial pooler.

        string targetSparsity;
        string minOverlap;
        string unlearningOverreactionRatio;
        string inhibitionPenalty;
        string nBucSynapse;
        string fanoutRadius;
        string permSinker;

        string spImageType;

        readonly HtmRegionFor2D spSheet;

        public Form1()
        {
            InitializeComponent();

            inputImagePictureBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(inputImagePictureBox_MouseWheel);

            inputWord = inputWordTextBox.Text;
            rawBitmap = new Int32[inputImagePictureBox.Width * inputImagePictureBox.Height];

            targetSparsity = targetSparsityTextBox.Text;
            minOverlap = minOverlapTextBox.Text;
            unlearningOverreactionRatio = underSparsityORTextBox.Text;
            inhibitionPenalty = inhibitionPenaltyTextBox.Text;
            nBucSynapse = nProximalSynapseTextBox.Text;
            fanoutRadius = fanoutRadiusTextBox.Text;
            permSinker = permSinkerTextBox.Text;

            spImageType = "Intensity";

            labelIndex = new labelDictionary();

            // Initialize the region
            spSheet = new HtmRegionFor2D(32, 32, 1);
            spSheet.TargetSparsity = int.Parse(targetSparsity.Replace("%", ""));
            spSheet.MinOverlap = int.Parse(minOverlap.Replace("%", ""));
            spSheet.UnlearningOverreactionRatio = int.Parse(unlearningOverreactionRatio.Replace("%", ""));
            initializeSpSheetInBackground();
        }

        #endregion

        #region Utility class

        class labelDictionary
        {
            Dictionary<string, int> labelStore;
            List<string> indexStore;
            public labelDictionary()
            {
                labelStore = new Dictionary<string,int>();
                indexStore = new List<string>();
            }
            public int ToIndex(string label)
            {
                if (labelStore.ContainsKey(label))
                {
                    return labelStore[label];
                }
                else
                {
                    int n = indexStore.Count;
                    indexStore.Add(label);
                    labelStore.Add(label, n);
                    return n;
                }
            }
            public string ToLabel(int i)
            {
                return indexStore[i];
            }
        }
        labelDictionary labelIndex;

        #endregion

        #region updateSpatialPooler: Feeding data to the spatial pooler

        private void updateSpatialPooler(bool screenRefresh = true)
        {
            if (!spInitBackgroundWorker.IsBusy)
            {
                // Feed the current inputBitmap to the spatial pooler.

                if (inputImage != null) inputImage.Dispose();
                inputImage = new Bitmap(inputImagePictureBox.Width, inputImagePictureBox.Height);

                using (var g = Graphics.FromImage(inputImage))
                {
                    drawInputImage(g, inputImage.Width, inputImage.Height);

                    var bitmapData = inputImage.LockBits(new Rectangle(0, 0, inputImage.Width, inputImage.Height),
                                                            ImageLockMode.ReadOnly, inputImage.PixelFormat);

                    var stride = Math.Abs(bitmapData.Stride);
                    var bytePerPixel = stride / bitmapData.Width;

                    if (bytePerPixel != 4)
                        throw new InvalidOperationException();

                    System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, rawBitmap, 0, rawBitmap.Length);
                    inputImage.UnlockBits(bitmapData);

                    // Convert the input bitmap image to a binary bit stream.
                    for (int i = 0; i < rawBitmap.Length; i++)
                        rawBitmap[i] = ((rawBitmap[i] & 0xFF000000) == 0xFF000000 && (rawBitmap[i] & 0x00F0F0F0) == 0) ? 1 : 0;

                    // Set environmental properties.
                    spSheet.DoLocalInhibition = spLocalInhibitionCheckBox.Checked;
                    spSheet.DoLearning = spLearningCheckBox.Checked;
                    spSheet.DoBoosting = spLearningCheckBox.Checked && spBoostCheckBox.Checked;
                    spSheet.DoUnlearning = spLearningCheckBox.Checked && spUnlearnCheckBox.Checked;

                    // Name this input image; this is to generate the class of this image
                    var label = describeInputImage();

                    // Now, feed the input to HTM CLA reagion.
                    spSheet.Write(rawBitmap, labelIndex.ToIndex(label));

                    // Read the occurence frequency of labels for this SDR
                    var labelHistogram = new List<KeyValuePair<int,int>>();
                    spSheet.Read(labelHistogram);

                    spLabelInferenceListBox.BeginUpdate();
                    spLabelInferenceListBox.Items.Clear();
                    spLabelInferenceListBox.Items.Add("Ans:"+label);
                    foreach (var kvp in labelHistogram)
                        spLabelInferenceListBox.Items.Add(String.Format("{0,4}:{1}",kvp.Key,labelIndex.ToLabel(kvp.Value)));
                    spLabelInferenceListBox.EndUpdate();
                }

                // Update the statistics on GUI.
                spatialPoolerStatsRefresh();
            }

            if (screenRefresh)
            {
                inputImagePictureBox.Refresh();
                spatialPoolerPictureBox.Refresh();
                reverseMapPictureBox.Refresh();
                spPermSpectrumPictureBox.Refresh();
            }
        }

        private string describeInputImage()
        {
            Matrix m;
            int dx, dy, theta, scale;
            float sinT, cosT;

            m = currentM.Clone();
            m.Multiply(transM, MatrixOrder.Append);

            dx = (int)(m.OffsetX);
            dy = (int)(m.OffsetY);
            cosT = m.Elements[0];    /*m11; cos(theta)*scale */
            sinT = -m.Elements[1];   /*m12; sin(theta)*scale */
            theta = (int)(Math.Round(Math.Atan2(sinT, cosT) * 180.0 / Math.PI));
            scale = (int)(Math.Round(Math.Abs(cosT * cosT + sinT * sinT) * 100.0));

            StringBuilder sb = new StringBuilder(128);
            sb.AppendFormat("\"{0}\" θ({1}) S({2}%) Δ({3},{4})", inputWord, theta, scale, dx, dy);

            return sb.ToString();
        }

        private void spatialPoolerStatsRefresh()
        {

            var s = new StringBuilder();

            s.AppendFormat("{0}", spSheet.GetStatsCount(HtmStatsKey.Ticks));
            clockStepTextBox.Text = s.ToString();
            s.Clear();

            s.Append(spSheet.ActiveColumnCount);
            s.AppendFormat(" ({0,5:F1}%)", 100.0F * spSheet.ActiveColumnCount / spSheet.TotalColumnCount);
            activeColumnCountTextBox.Text = s.ToString();
            s.Clear();

            if (spSheet.GetStatsCount(HtmStatsKey.SpPreactiveCount) == 0)
                inhibitedColumnCountTextBox.Text = "None";
            else
            {
                s.Append(spSheet.PreactiveColumnCount);
                s.AppendFormat(" ({0,5:F1}%)", 100.0F * spSheet.GetStatsCount(HtmStatsKey.SpInhibitionCount) /
                                                    spSheet.GetStatsCount(HtmStatsKey.SpPreactiveCount));
                inhibitedColumnCountTextBox.Text = s.ToString();
                s.Clear();
            }

            s.Append(spSheet.GetStatsCount(HtmStatsKey.SpUnlearnCount));
            s.AppendFormat(" ({0,5:F1}%)", 100.0F * spSheet.GetStatsCount(HtmStatsKey.SpUnlearnCount) /
                                                    spSheet.TotalColumnCount);
            unlearnColumnTextBox.Text = s.ToString();
            s.Clear();

            int ccMin, ccAve, ccMax;
            spSheet.GetConnectedSynapseCount(out ccMin, out ccAve, out ccMax);
            int n = int.Parse(nBucSynapse);
            s.AppendFormat("Min: {0} ({1,5:F1}%){2}", ccMin, 100.0F * ccMin / n, System.Environment.NewLine);
            s.AppendFormat("Ave: {0} ({1,5:F1}%){2}", ccAve, 100.0F * ccAve / n, System.Environment.NewLine);
            s.AppendFormat("Max: {0} ({1,5:F1}%)", ccMax, 100.0F * ccMax / n);
            connectedSynapseTextBox.Text = s.ToString();
            s.Clear();

            s.AppendFormat("{0}", spSheet.GetStatsCount(HtmStatsKey.SpInhibitionRadius));
            inhibitionRadiusTextBox.Text = s.ToString();
            s.Clear();

            s.AppendFormat("{0:F3}ms", spSheet.GetStatsMilliseconds(HtmStatsKey.SpOverlapTime));
            spOverlapTimeTextBox.Text = s.ToString();
            s.Clear();

            s.AppendFormat("{0:F3}ms", spSheet.GetStatsMilliseconds(HtmStatsKey.SpInhibitionTime));
            spInhibitionTimeTextBox.Text = s.ToString();
            s.Clear();

            s.AppendFormat("{0:F3}ms", spSheet.GetStatsMilliseconds(HtmStatsKey.SpLearningTime));
            spLearningTimeTextBox.Text = s.ToString();
            s.Clear();

            int ltMin, ltAve, ltMax, m;
            spSheet.GetLabelTableCount(out ltMin, out ltAve, out ltMax);
            m = ltMax > 0 ? ltMax : 1;
            s.AppendFormat("Min: {0} ({1,5:F1}%){2}", ltMin, 100.0F * ltMin / m, System.Environment.NewLine);
            s.AppendFormat("Ave: {0} ({1,5:F1}%){2}", ltAve, 100.0F * ltAve / m, System.Environment.NewLine);
            s.AppendFormat("Max: {0} ({1,5:F1}%)", ltMax, 100.0F * ltMax / m);
            spLabelCapacityTextBox.Text = s.ToString();
            s.Clear();

            s.AppendFormat("{0:F3}ms",
                    spSheet.GetStatsMilliseconds(HtmStatsKey.SpOverlapTime)
                    + spSheet.GetStatsMilliseconds(HtmStatsKey.SpInhibitionTime)
                    + spSheet.GetStatsMilliseconds(HtmStatsKey.SpLearningTime));
            spTotalTimeTextBox.Text = s.ToString();
            s.Clear();
        }

        #endregion

        #region inputWordTextBox

        private void inputWordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    inputWord = inputWordTextBox.Text;
                    updateSpatialPooler();
                    e.Handled = true;
                    break;
                case (char)Keys.Escape:
                    inputWordTextBox.Text = inputWord;
                    e.Handled = true;
                    break;
            }
        }

        #endregion

        #region inputImagePictureBox

        // inputBitmap transformation Matrices:
        //   transM is the transient matrix applied after currentM.
        //   it represents the transformation while you're dragging the pointer.
        //   (see also inputImageBox_Paint)
        Matrix currentM = new Matrix();
        Matrix transM = new Matrix();

        bool isDragging = false;
        bool isZooming = false;
        bool showBottomUpConnects = false;

        MouseButtons dragButton;
        int x0, y0;
        int x1, y1;
        int xbuc, ybuc;
        int zoomScale;  // unit: percent

        const int dragRotateMin = 15;
        const int wheelScaleInc = 10;
        const int sightRadius = 3;

        Bitmap inputBGImage;
        Bitmap inputImage;  // This image is the inputBitmap for spSheet.

        private void drawInputImage(Graphics g, int width, int height)
        {
            using (var brush = new SolidBrush(Color.Black))
            {
                if (inputBGImage != null)
                    g.DrawImage(inputBGImage, 0, 0);

                g.Transform = currentM;
                g.MultiplyTransform(transM, MatrixOrder.Append);
                g.InterpolationMode = InterpolationMode.High;
                g.DrawString(inputWord, inputStringFontDialog.Font, brush, 0, 0);
                g.ResetTransform();
            }
        }

        private void inputImagePictureBox_Paint(object sender, PaintEventArgs e)
        {
            drawInputImage(e.Graphics, inputImagePictureBox.Width, inputImagePictureBox.Height);

            // Draw a rubber band line while dragging.
            if (isDragging)
                e.Graphics.DrawLine(Pens.Cyan, x0, y0, x1, y1);

            // Draw a laser sight while zooming.
            if (isZooming)
                e.Graphics.DrawEllipse(Pens.Cyan, x0 - sightRadius, y0 - sightRadius, sightRadius * 2 + 1, sightRadius * 2 + 1);

            if (showBottomUpConnects)
                spSheet.DrawColumnSynapseSpraySpecific(e.Graphics, inputImagePictureBox.Width, xbuc, ybuc);
        }

        private void inputImagePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isDragging)    // Let us ignore button down events during dragging.
            {
                // PictureBox needs focus to receive a mouse wheel event.
                inputImagePictureBox.Focus();

                if (isZooming)
                {
                    isZooming = false;
                    updateSpatialPooler();
                }
                else
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                        case MouseButtons.Right:
                            isDragging = true;
                            dragButton = e.Button;
                            x0 = x1 = e.X;
                            y0 = y1 = e.Y;
                            currentM.Multiply(transM, MatrixOrder.Append);
                            transM.Reset();
                            break;
                    }
                }
            }
        }

        private void inputImagePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int dx = e.X - x0;
                int dy = e.Y - y0;
                float dragDegree;

                switch (dragButton)
                {
                    case MouseButtons.Left:     // Translate by dx,dy
                        transM.Reset();
                        transM.Translate(dx, dy, MatrixOrder.Append);

                        lastTrfmTextBox.Text = "Move dx=" + dx + " dy=" + dy;
                        x1 = e.X;
                        y1 = e.Y;
                        inputImagePictureBox.Invalidate();
                        break;

                    case MouseButtons.Right:    // Rotate by atan2(-dy,dx)
                        if (Math.Abs(dx) < dragRotateMin && Math.Abs(dy) < dragRotateMin)
                        {
                            dragDegree = 0F;
                            transM.Reset();
                        }
                        else
                        {
                            dragDegree = (float)Math.Round(Math.Atan2(dy, dx) * 180.0 / Math.PI);
                            transM.Reset();
                            transM.RotateAt(dragDegree, new PointF() { X = x0, Y = y0 }, MatrixOrder.Append);
                        }

                        lastTrfmTextBox.Text = "Rotate theta=" + (-dragDegree) + " at (" + x0 + "," + y0 + ")";
                        x1 = e.X;
                        y1 = e.Y; 
                        inputImagePictureBox.Invalidate();
                        break;
                }
            }
        }

        private void inputImagePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                if (e.Button == dragButton)
                {
                    isDragging = false;
                    updateSpatialPooler();
                }
            }
        }

        private void inputImagePictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!isDragging)
            {
                if (!isZooming)
                {
                    currentM.Multiply(transM, MatrixOrder.Append);
                    isZooming = true;
                    zoomScale = 100;
                    x0 = e.X;
                    y0 = e.Y;
                }

                zoomScale += (e.Delta > 0 ? wheelScaleInc : -wheelScaleInc);
                if (zoomScale <= 0)
                    zoomScale = wheelScaleInc;

                transM.Reset();
                transM.Translate(-x0, -y0);
                transM.Scale(zoomScale / 100.0F, zoomScale / 100.0F, MatrixOrder.Append);
                transM.Translate(x0, y0, MatrixOrder.Append);

                lastTrfmTextBox.Text = "Zoom " + zoomScale + "%" +
                                            " at (" + x0 + "," + y0 + ")";
                inputImagePictureBox.Invalidate();
            }
        }

        private void cancelTrfmButton_Click(object sender, EventArgs e)
        {
            lastTrfmTextBox.Text = null;

            transM.Reset();
            isZooming = false;
            updateSpatialPooler();
        }

        private void repeatTrfmButton_Click(object sender, EventArgs e)
        {
            currentM.Multiply(transM, MatrixOrder.Append);
            isZooming = false;
            updateSpatialPooler();
        }

        private void reverseTrfmButton_Click(object sender, EventArgs e)
        {
            using (var inv = transM.Clone())
            {
                inv.Invert();

                currentM.Multiply(inv, MatrixOrder.Append);
                updateSpatialPooler();
            }
        }

        private void resetTrfmButton_Click(object sender, EventArgs e)
        {
            lastTrfmTextBox.Text = null;

            currentM.Reset();
            transM.Reset();
            isZooming = false;
            updateSpatialPooler();
        }

        private void changeFontButton_Click(object sender, EventArgs e)
        {
            if (inputStringFontDialog.ShowDialog() != DialogResult.Cancel)
                updateSpatialPooler();
        }

        private void setBGbutton_Click(object sender, EventArgs e)
        {
            if (inputImageBGFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (inputBGImage != null)
                    inputBGImage.Dispose();

                // Use Load() to obtain the inputBitmap.
                inputImagePictureBox.Load(inputImageBGFileDialog.FileName);
                inputBGImage = new Bitmap(inputImagePictureBox.Image);
                inputImagePictureBox.Image.Dispose();
                inputImagePictureBox.Image = null;

                updateSpatialPooler();
            }
        }

        private void clearBGbutton_Click(object sender, EventArgs e)
        {
            if (inputBGImage != null)
            {
                inputBGImage.Dispose();
                inputBGImage = null;

                updateSpatialPooler();
            }
        }

        #endregion

        #region spatialPoolerPictureBox

        int tipSpX, tipSpY;

        private void spatialPoolerPictureBox_Paint(object sender, PaintEventArgs e)
        {
            int tileW, tileH;

            tileW = spatialPoolerPictureBox.Width / spSheet.Width;
            tileH = spatialPoolerPictureBox.Height / spSheet.Height;

            for (int spY = 0, y = 0; spY < spSheet.Height; spY++, y += tileH)
                for (int spX = 0, x = 0; spX < spSheet.Width; spX++, x += tileW)
                {
                    Color c;

                    if (spImageType == "Boost")
                    {
                        int boost = spSheet.GetColumnBoost(spX, spY);
                        if (boost > 0)
                            boost = Math.Min(127 + boost, 255);
                        c = Color.FromArgb(boost, 0, 0);
                    }
                    else if (spImageType == "ConnectedSynapse")
                    {
                        int count = spSheet.GetConnectedSynapseCount(spX, spY);
                        count = Math.Min(256 * count / spSheet.MaxBottomUpIntensity, 255);
                        c = Color.FromArgb(count, count, count);
                    }
                    else if (spImageType == "DutyCycle")
                    {
                        int preactive = spSheet.GetColumnPreactiveStateCount(spX, spY);
                        int active = spSheet.GetColumnActiveStateCount(spX, spY);
                        int inhibited = preactive - active;

                        active = Math.Abs(active);
                        inhibited = Math.Abs(inhibited);

                        active = Math.Min(active, 255);
                        inhibited = Math.Min(inhibited, 255);

                        c = Color.FromArgb(active, 0, inhibited);
                    }
                    else
                    {
                        if (spSheet.GetColumnState(spX, spY) == HtmColumnState.Inactive)
                            c = Color.Black;
                        else
                        {
                            int intensity = spSheet.GetIntensity(spX, spY) * 2;

                            if (intensity > 128) intensity = 128;
                            if (intensity < -128) intensity = -128;

                            switch (spSheet.GetColumnState(spX, spY))
                            {
                                case HtmColumnState.Active:
                                    intensity = 127 + Math.Abs(intensity);
                                    c = Color.FromArgb(intensity, 0, 0);
                                    break;
                                case HtmColumnState.Preactive:
                                    if (intensity < 0)
                                        c = Color.FromArgb(0, 0, 127 - intensity);
                                    else
                                        c = Color.FromArgb(0, 127 + intensity, 0);
                                    break;
                                default:
                                    intensity = 127 + Math.Abs(intensity);
                                    c = Color.FromArgb(intensity, intensity, intensity);
                                    break;
                            }
                        }
                    }

                    using (var brush = new SolidBrush(c))
                        e.Graphics.FillRectangle(brush, x, y, tileW, tileH);
                }

            for (int spY = 0, y = 0; spY < spSheet.Height; spY++, y += tileH)
                for (int spX = 0, x = 0; spX < spSheet.Width; spX++, x += tileW)
                    e.Graphics.DrawRectangle(Pens.Silver, x, y, tileW, tileH);

            if (showBottomUpConnects)
            {
                int radius = spSheet.GetStatsCount(HtmStatsKey.SpInhibitionRadius);
                e.Graphics.DrawEllipse(Pens.Purple, (xbuc - radius) * tileW, (ybuc - radius) * tileH,
                                                (2 * radius + 1) * tileW, (2 * radius + 1) * tileH);
                e.Graphics.DrawRectangle(Pens.Red, xbuc * tileW, ybuc * tileH, tileW, tileH);
            }
        }

        private void spatialPoolerPictureBox_MouseEnter(object sender, EventArgs e)
        {
            tipSpX = -1;
            tipSpY = -1;
            spatialPoolerToolTip.Active = false;
            spatialPoolerToolTip.Active = true;
        }

        private void spatialPoolerPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int x = spSheet.Width * e.X / spatialPoolerPictureBox.Width;
            int y = spSheet.Height * e.Y / spatialPoolerPictureBox.Height;

            if (x < 0 || spSheet.Width <= x)
                return;
            if (y < 0 || spSheet.Height <= y)
                return;

            if (x != tipSpX || y != tipSpY)
            {
                var s = new StringBuilder();

                s.AppendFormat("column[{0},{1}]\n", y, x);
                s.AppendFormat("=>{0}\n", spSheet.GetColumnState(x, y));
                s.AppendFormat("  intensity {0}\n", spSheet.GetIntensity(x, y));
                s.AppendFormat("  connected synapse {0}\n", spSheet.GetConnectedSynapseCount(x, y));
                s.AppendFormat("  preactive {0}", spSheet.GetColumnPreactiveStateCount(x, y));
                s.AppendFormat("  active {0}\n", spSheet.GetColumnActiveStateCount(x, y));
                s.AppendFormat("  column boosting {0}", spSheet.GetColumnBoost(x, y));
                spatialPoolerToolTip.SetToolTip((Control)sender, s.ToString());

                tipSpX = x;
                tipSpY = y;

                if (e.Button == MouseButtons.Left)
                {
                    if (xbuc != x) xbuc = x;
                    if (ybuc != y) ybuc = y;
                    showBottomUpConnects = true;
                    inputImagePictureBox.Refresh();
                    spatialPoolerPictureBox.Refresh();
                    reverseMapPictureBox.Refresh();
                }
                else if (e.Button == MouseButtons.Right && showBottomUpConnects)
                {
                    showBottomUpConnects = false;
                    inputImagePictureBox.Refresh();
                    spatialPoolerPictureBox.Refresh();
                    reverseMapPictureBox.Refresh();
                }
                spPermSpectrumPictureBox.Refresh();
            }
        }

        private void spatialPoolerPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xbuc = tipSpX;
                ybuc = tipSpY;
                showBottomUpConnects = true;
                inputImagePictureBox.Refresh();
                spatialPoolerPictureBox.Refresh();
                reverseMapPictureBox.Refresh();
                spPermSpectrumPictureBox.Refresh();
            }
            else if (e.Button == MouseButtons.Right && showBottomUpConnects)
            {
                showBottomUpConnects = false;
                inputImagePictureBox.Refresh();
                spatialPoolerPictureBox.Refresh();
                reverseMapPictureBox.Refresh();
                spPermSpectrumPictureBox.Refresh();
            }
        }

        private void spPictureBoxIntensityRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radiobox = sender as RadioButton;

            if (radiobox.Checked)
            {
                spImageType = "Intensity";
                spatialPoolerPictureBox.Refresh();
            }
        }

        private void spPictureBoxDutyCycleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radiobox = sender as RadioButton;

            if (radiobox.Checked)
            {
                spImageType = "DutyCycle";
                spatialPoolerPictureBox.Refresh();
            }
        }

        private void spPictureBoxBoostRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radiobox = sender as RadioButton;

            if (radiobox.Checked)
            {
                spImageType = "Boost";
                spatialPoolerPictureBox.Refresh();
            }
        }

        private void spPictureBoxConnectedSynapseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radiobox = sender as RadioButton;

            if (radiobox.Checked)
            {
                spImageType = "ConnectedSynapse";
                spatialPoolerPictureBox.Refresh();
            }
        }

        #endregion

        #region spPermSpectrumPictureBox

        private void spPermSpectrumPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (showBottomUpConnects)
                spSheet.DrawBucPermSpectram(e.Graphics, inputImagePictureBox.Width, xbuc, ybuc);
        }

        #endregion

        #region reverseMapPictureBox

        private void reverseMapPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (showBottomUpConnects)
                spSheet.DrawColumnSynapseSpraySpecific(e.Graphics, inputImagePictureBox.Width, xbuc, ybuc);
            else
                for (int spY = 0; spY < spSheet.Height; spY++)
                    for (int spX = 0; spX < spSheet.Width; spX++)
                        if (spSheet.GetColumnState(spX, spY) == HtmColumnState.Active)
                            spSheet.DrawColumnSynapseSpray(e.Graphics, inputImagePictureBox.Width, spX, spY);
        }

        #endregion

        #region Spatial Pooler - Control

        private void spLocalInhibitionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            inhibitionPenaltyTextBox.Enabled = spLocalInhibitionCheckBox.Checked;

            updateSpatialPooler();
        }

        private void spLearningCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                spBoostCheckBox.Enabled = true;
                spUnlearnCheckBox.Enabled = true;
                underSparsityORTextBox.Enabled = spUnlearnCheckBox.Checked;
                updateSpatialPooler();
            }
            else
            {
                spBoostCheckBox.Enabled = false;
                spUnlearnCheckBox.Enabled = false;
                underSparsityORTextBox.Enabled = false;
            }
        }

        private void spUnlearnCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            underSparsityORTextBox.Enabled = spUnlearnCheckBox.Checked;
        }

        private bool validatePercentValueOfTextBox(TextBox textbox, int min, int max, out int perc)
        {
            string s = textbox.Text;

            s.Trim();
            if (s.EndsWith("%"))
                s = s.Substring(0, s.Length - 1).Trim();

            if (!int.TryParse(s, out perc) || perc < min || max < perc)
            {
                textbox.Select(0, textbox.Text.Length);
                return false;
            }
            else
            {
                textbox.Text = s + "%";
                return true;
            }
        }

        private void targetSparcityTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textbox = sender as TextBox;
            int perc;

            if (!validatePercentValueOfTextBox(textbox, 1, 99, out perc))
            {
                e.Cancel = true;
                return;
            }

            targetSparsity = textbox.Text;
            if (spSheet.TargetSparsity != perc)
            {
                spSheet.TargetSparsity = perc;
                updateSpatialPooler();
            }
        }

        private void targetSparcityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    ((TextBox)sender).Parent.Focus();   // This causes validation.
                    e.Handled = true;
                    break;
                case (char)Keys.Escape:
                    targetSparsityTextBox.Text = targetSparsity;
                    e.Handled = true;
                    break;
            }
        }

        private void minOverlapTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textbox = sender as TextBox;
            int perc;

            if (!validatePercentValueOfTextBox(textbox, 1, 99, out perc))
            {
                e.Cancel = true;
                return;
            }

            minOverlap = textbox.Text;
            if (spSheet.MinOverlap != perc)
            {
                spSheet.MinOverlap = perc;
                updateSpatialPooler();
            }
        }

        private void minOverlapTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    ((TextBox)sender).Parent.Focus();   // This causes validation.
                    e.Handled = true;
                    break;
                case (char)Keys.Escape:
                    minOverlapTextBox.Text = minOverlap;
                    e.Handled = true;
                    break;
            }
        }

        private void underSparsityORTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textbox = sender as TextBox;
            int perc;

            if (!validatePercentValueOfTextBox(textbox, 100, 200, out perc))
            {
                e.Cancel = true;
                return;
            }

            unlearningOverreactionRatio = textbox.Text;
            if (spSheet.UnlearningOverreactionRatio != perc)
            {
                spSheet.UnlearningOverreactionRatio = perc;
                updateSpatialPooler();
            }
        }

        private void underSparsityORTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    ((TextBox)sender).Parent.Focus();   // This causes validation.
                    e.Handled = true;
                    break;
                case (char)Keys.Escape:
                    underSparsityORTextBox.Text = unlearningOverreactionRatio;
                    e.Handled = true;
                    break;
            }
        }

        private void inhibitionPenaltyTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textbox = sender as TextBox;
            int perc;

            if (!validatePercentValueOfTextBox(textbox, 1, 99, out perc))
            {
                e.Cancel = true;
                return;
            }

            inhibitionPenalty = textbox.Text;
            if (spSheet.LocalInhibitionPenaltyRatio != perc)
            {
                spSheet.LocalInhibitionPenaltyRatio = perc;
                updateSpatialPooler();
            }
        }

        private void inhibitionPenaltyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    ((TextBox)sender).Parent.Focus();   // This causes validation.
                    e.Handled = true;
                    break;
                case (char)Keys.Escape:
                    inhibitionPenaltyTextBox.Text = inhibitionPenalty;
                    e.Handled = true;
                    break;
            }
        }

        private void nBucSynapseTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textbox = sender as TextBox;
            int n;

            if (!int.TryParse(textbox.Text, out n) || n < 1)
            {
                textbox.Select(0, textbox.Text.Length);
                e.Cancel = true;
            }
        }

        private void nBucSynapseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Escape:
                    nProximalSynapseTextBox.Text = nBucSynapse;
                    e.Handled = true;
                    break;
            }
        }

        private void fanoutRadiusTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textbox = sender as TextBox;
            int n;

            if (!int.TryParse(textbox.Text, out n) || n < 0)
            {
                textbox.Select(0, textbox.Text.Length);
                e.Cancel = true;
            }
        }

        private void fanoutRadiusTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Escape:
                    fanoutRadiusTextBox.Text = fanoutRadius;
                    e.Handled = true;
                    break;
            }
        }

        private void permSinkerTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textbox = sender as TextBox;
            int n;

            if (!int.TryParse(textbox.Text, out n) || n < 0)
            {
                textbox.Select(0, textbox.Text.Length);
                e.Cancel = true;
            }
        }

        private void permSinkerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Escape:
                    permSinkerTextBox.Text = permSinker;
                    e.Handled = true;
                    break;
            }
        }

        #endregion

        #region Spatial Pooler - Initialize

        private void spInitButton_Click(object sender, EventArgs e)
        {
            nBucSynapse = nProximalSynapseTextBox.Text;
            fanoutRadius = fanoutRadiusTextBox.Text;
            permSinker = permSinkerTextBox.Text;
            initializeSpSheetInBackground();
        }

        private void initializeSpSheetInBackground()
        {
            if (!spInitBackgroundWorker.IsBusy)
                spInitBackgroundWorker.RunWorkerAsync();
        }

        private void spInitBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var w = sender as BackgroundWorker;
            var t = Task.Factory.StartNew(() =>
            {
                spSheet.InitializeBucSynapses(
                                inputImagePictureBox.Width,
                                inputImagePictureBox.Height,
                                int.Parse(fanoutRadius),
                                int.Parse(nBucSynapse),
                                int.Parse(permSinker)
                                );
            });

            while (!t.IsCompleted)
            {
                System.Threading.Thread.Sleep(250);
                w.ReportProgress(spSheet.BucInitProgress);
            }
        }

        private void spInitBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            spStatusLabel.Text = "  Initializing ... " + e.ProgressPercentage + "%";
        }

        private void spInitBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            spStatusLabel.Text = e.Error != null ? "  Error :" + e.Error : "";
            updateSpatialPooler();
        }

        #endregion

        #region Images Drag & Drop

        private void transferImage(Control owner, Control image)
        {
            using (var bitmap = new Bitmap(image.Width, image.Height))
            {
                image.DrawToBitmap(bitmap, new Rectangle(0, 0, image.Width, image.Height));
                owner.DoDragDrop(bitmap, DragDropEffects.Copy);
            }
        }

        private void inputImageDragLabel_MouseDown(object sender, MouseEventArgs e)
        {
            transferImage((Control)sender, inputImagePictureBox);
        }

        private void spatialPoolerDragLabel_MouseDown(object sender, MouseEventArgs e)
        {
            transferImage((Control)sender, spatialPoolerPictureBox);
        }

        private void permanenceSpectralDragLabel_MouseDown(object sender, MouseEventArgs e)
        {
            transferImage((Control)sender, spPermSpectrumPictureBox);
        }

        private void reverseMapDragLabel_MouseDown(object sender, MouseEventArgs e)
        {
            transferImage((Control)sender, reverseMapPictureBox);
        }

        #endregion

    }
}
