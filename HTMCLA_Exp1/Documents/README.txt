
Purpose of this project
  The sole purpose of this project is to study HTM CLA by myself.  I publish this software under GPLv3,
  only because I think it may be useful for others to learn CLA, too.  This software is provided AS-IS.

  My special interests in this project are:

   - To study the behaviors of HTM CLA so that I can understand HTM CLA deeply.

   - To determine the required amount of calculation and memory so that I can understand
     what optimization can be used in the implementation level with regard to the given
	 configuration of HTM CLA. e.g. the region size, input size, learning cost, and so forth.
  
  The software contains numerous modifications to the original HTM CLA.  Do not think that
  this is the pure implementation of HTM CLA.  Always refer to the white paper provided
  by Numenta.org for the "correct" algorithm.

  References:
    * Numenta Homepage (http://numenta.org/) sponsoring Nupic implementation of HTM CLA.
	  Numenta @ Ohloh (https://www.ohloh.net/p/nupic)
	* HTM CLA White Paper (http://numenta.org/cla-white-paper.html)
	* Nupic ML (http://lists.numenta.org/mailman/listinfo)
	  Nupic ML @ MarkMail (http://nupic.markmail.org/)


Bug Report
  You're welcome to send me a bug report or a test result.  However, do not expect me to integrate
  changes requested by you.  Since this is my personal project for studying purpose only, I may abandon
  the code whenever I want to do so.
  
  Still, I am open to discuss any aspect of the implementation details of this project.
  Feel free to contact me by mail(h2suzuki@gmail.com) or in Nupic mailing list.  If you think
  your finding is good to share with others, I recommend you to post the information to the ML.

  Note that I am not a neuroscientist.  It is very likely that I cannot answer questions
  related to biology.


The major differences between the implementation and the algorithms written in HTM CLA White Paper:

  - Preactive state is introduced for column, which is not mentioned in the white paper.

    Preactive columns are those which have enough overlap to the input bits but we are not sure if they will survive
	after inhibition. Preactive state is usually a transient state.  A preactive column will end up with
	an inhibited column	or an active column.  If we have enough active columns before examining all
	preactive columns, those yet-to-examined columns will remain in preactive state.

  - Local inhibition is done by giving penalty to the preactive columns around the active columns rather
    than selecting the kth highest intensity columns mentioned in the white paper.
 
  - The inhibition radius is calculated according to the density of preactive columns in the region rather
    than according to the size of the receptive field.
  
      inhibitionRadius = (int)Math.Sqrt(preactiveColumns.Count / targetActiveColumnCount);

	In this way, we can put more inhibition when we need to inhibit more preactive columns.
 
  - Almost every computation is done with integers only.
  
    Especially, division and modulo are avoided in the time-critical path, because these are 
	slow operations in GPGPU.  Permanence is stored as an integer [0-255] instead of 
	a floating point[0.0-1.0].  Boosting is calculated using integers only, and so forth.

  - Column Boosting is carried out by addition rather than multiplication.

  - OverlapDutyCycle and ActiveDutyCycle are not implemented in the manner written in the white paper.

    OverlapDutyCycle is replaced with another unlearning column selection logic.  Rather than picking up
	columns with large OverlapDutyCycle, I pick up the columns with the smallest number of connected synapses.
	Also, I omit to	perform unlearning as long as I can achieve the target sparsity.  i.e. I have a good
	number of preactive	columns in my hand.

	ActiveDutyCycle is replaced with the inhibition frequency.  The inhibition frequency is calculated by
	the average number of the times a column is inhibited.  I wrote some more details in the code comment of
	HtmColumn class.

  - Unlearning Overreaction Mechanism

    This is not a proved mechanism.  Probably I will prepare some stats to prove or disprove the goodness
	of this.
	
	When unlearning takes place, the problem to solve is how many columns I should pick to make them unlearn.
	The basic idea is to pick columns by the difference between how many active columns we expect and how
	many actually we get.

	In this case, it might be very slow to unlearn columns when we are close to the target active column
	count.  Overreaction tries to unlearn more columns to unlearn.  This mechanism might not be needed
	after all.


Other implementation details:

  - File organization

    Not much complicated.  The source files are minimum.

	    Form1.cs			... All GUI stuff
		Form2.cs			... Additional graph window (not implemented yet)
		HtmSheet.cs			...	HTM CLA
		MersenneTwister.cs	... A famous random number generator, C# implementation borrowed from http://www.takel.jp/mt/
		Program.cs			... Auto-generated code by VS2012

	Plus, this solution contains some documentations under Documents folder and GPLv3 LICENSE.txt 

  - Fanout radius

    "fanoutRadius" indicates the horizontal/vertical radius of the square area which the potential 
    synapses of the bottom-up segment of a column connects to.  The size of the square area is
    (2*fanoutRadius+1) x (2*fanoutRadius+1).  The minimum fanoutRadius is 0, which assumes
    the area contains only 1 pixel.

    For the area of the the densest synapse case, we can have (2*fanoutRadius+1) x (2*fanoutRadius+1)
    synapses at most where each pixel is connected to a unique synapse.  On the other side, if 
    the number of the synapses is given by nSynapses, the smallest square area would be of
    the diameter of sqrt(nSynapses).

    HtmRegionFor2D::InitializeBucSynapses() uses the following rules to decide their values.
    
	    1) If a non-negative fanoutRadius is given, use that size.  Otherwise, use the default size.
           The default fanoutRadius is of the size that the areas overlap by 150% each side.
    
	    2) After deciding fanoutRadius, determine the number of the potential synapses (nSynapse)
		   of a column.

         - If nSynapses is omitted, assume the default number of 256 potential synapses per fanoutArea.

         - If nSynapses is out of range (i.e. nSynapse<1 || all pixels in the area < nSynapse),
		   adjust nSynapses to be either 1 or the number of pixels in fanoutArea.

           Hence, each pixel is connected to a column when we require the densest potential synapses.
    
	In order to best-utilize the resource assigned to a synapse, any two synapses from one single
    column should not connect to the same pixel.  To achieve this, an array is setup to cover all pixels
    in an area, shuffle the array, then pick nSynapses number of elements from the beginning of the array.
	In such a way, we can choose connections to the pixels randomly.

  - Label Table

    This is a trial to convert the current SDR to the actual value.  The idea is borrowed from the classifier
	on top on the temporal pooler.  The time is not involved here, though.

	Each column has a table to store a linked list.  When the SDR is generated from an input image,
	an integer is put together with the image.  The integer indicates the class of the image.
	I call it "label" of the image.

	The integer, or the label, is bound to the active columns of the SDR.  If one active column
	participates many kinds of input images, it will have many labels.  It will also have outdated
	labels after the column	unlearns some input images.

	By taking union of all labels given by a specific set of active columns, we can make a poll for
	what this SDR means.  The result can be obtained through read() interface of HtmRegionFor2D class.


You Have Been Warned.  Have fun. :)

THE END OF THIS FILE.