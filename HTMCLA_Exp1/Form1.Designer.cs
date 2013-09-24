namespace HTMCLA_Exp1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (inputImage != null)
                inputImage.Dispose();

            if (inputBGImage != null)
                inputBGImage.Dispose();

            if (currentM != null)
                currentM.Dispose();

            if (transM != null)
                transM.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.inputWordTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.inputImagePictureBox = new System.Windows.Forms.PictureBox();
            this.inputImageDragLabel = new System.Windows.Forms.Label();
            this.trfmGroupBox = new System.Windows.Forms.GroupBox();
            this.reverseTrfmButton = new System.Windows.Forms.Button();
            this.cancelTrfmButton = new System.Windows.Forms.Button();
            this.resetTrfmButton = new System.Windows.Forms.Button();
            this.repeatTrfmButton = new System.Windows.Forms.Button();
            this.lastTrfmTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.effectGroupBox = new System.Windows.Forms.GroupBox();
            this.clearBGbutton = new System.Windows.Forms.Button();
            this.setBGbutton = new System.Windows.Forms.Button();
            this.changeFontButton = new System.Windows.Forms.Button();
            this.spatialPoolerPictureBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.activeColumnCountTextBox = new System.Windows.Forms.TextBox();
            this.inputStringFontDialog = new System.Windows.Forms.FontDialog();
            this.uiToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.nProximalSynapseTextBox = new System.Windows.Forms.TextBox();
            this.fanoutRadiusTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.permSinkerTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.spInitButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.targetSparsityTextBox = new System.Windows.Forms.TextBox();
            this.minOverlapTextBox = new System.Windows.Forms.TextBox();
            this.spPermSpectrumPictureBox = new System.Windows.Forms.PictureBox();
            this.spUnlearnCheckBox = new System.Windows.Forms.CheckBox();
            this.spBoostCheckBox = new System.Windows.Forms.CheckBox();
            this.spLearningCheckBox = new System.Windows.Forms.CheckBox();
            this.inhibitionPenaltyTextBox = new System.Windows.Forms.TextBox();
            this.inhibitedColumnCountTextBox = new System.Windows.Forms.TextBox();
            this.unlearnColumnTextBox = new System.Windows.Forms.TextBox();
            this.inhibitionRadiusTextBox = new System.Windows.Forms.TextBox();
            this.underSparsityORTextBox = new System.Windows.Forms.TextBox();
            this.spLabelCapacityTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.spPictureBoxConnectedSynapseRadioButton = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.spPictureBoxBoostRadioButton = new System.Windows.Forms.RadioButton();
            this.spStatusLabel = new System.Windows.Forms.Label();
            this.spPictureBoxDutyCycleRadioButton = new System.Windows.Forms.RadioButton();
            this.permanenceSpectralDragLabel = new System.Windows.Forms.Label();
            this.spatialPoolerDragLabel = new System.Windows.Forms.Label();
            this.spPictureBoxIntensityRadioButton = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.reverseMapPictureBox = new System.Windows.Forms.PictureBox();
            this.reverseMapDragLabel = new System.Windows.Forms.Label();
            this.spControlGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.spLocalInhibitionCheckBox = new System.Windows.Forms.CheckBox();
            this.spStatsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.spLabelInferenceListBox = new System.Windows.Forms.ListBox();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spTotalTimeTextBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.spLearningTimeTextBox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.spInhibitionTimeTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.spOverlapTimeTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.connectedSynapseTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.clockStepTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputImageBGFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.spatialPoolerToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.spInitBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputImagePictureBox)).BeginInit();
            this.trfmGroupBox.SuspendLayout();
            this.effectGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spatialPoolerPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPermSpectrumPictureBox)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reverseMapPictureBox)).BeginInit();
            this.spControlGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.spStatsGroupBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input String:";
            // 
            // inputWordTextBox
            // 
            this.inputWordTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputWordTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.inputWordTextBox.Location = new System.Drawing.Point(8, 27);
            this.inputWordTextBox.MaxLength = 128;
            this.inputWordTextBox.Name = "inputWordTextBox";
            this.inputWordTextBox.Size = new System.Drawing.Size(256, 26);
            this.inputWordTextBox.TabIndex = 0;
            this.inputWordTextBox.Text = "R";
            this.uiToolTip.SetToolTip(this.inputWordTextBox, "Enter to submit the current string (ESC to reset it)");
            this.inputWordTextBox.WordWrap = false;
            this.inputWordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputWordTextBox_KeyPress);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel4.Controls.Add(this.label1);
            this.flowLayoutPanel4.Controls.Add(this.inputWordTextBox);
            this.flowLayoutPanel4.Controls.Add(this.label7);
            this.flowLayoutPanel4.Controls.Add(this.inputImagePictureBox);
            this.flowLayoutPanel4.Controls.Add(this.inputImageDragLabel);
            this.flowLayoutPanel4.Controls.Add(this.trfmGroupBox);
            this.flowLayoutPanel4.Controls.Add(this.effectGroupBox);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel4.Size = new System.Drawing.Size(280, 542);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Input Image:";
            // 
            // inputImagePictureBox
            // 
            this.inputImagePictureBox.BackColor = System.Drawing.Color.White;
            this.inputImagePictureBox.Location = new System.Drawing.Point(8, 78);
            this.inputImagePictureBox.Name = "inputImagePictureBox";
            this.inputImagePictureBox.Size = new System.Drawing.Size(256, 256);
            this.inputImagePictureBox.TabIndex = 0;
            this.inputImagePictureBox.TabStop = false;
            this.uiToolTip.SetToolTip(this.inputImagePictureBox, "Left-drag: move the string\r\nRight-drag: rotate the string\r\nWheel-scroll: zoom the" +
        " string");
            this.inputImagePictureBox.WaitOnLoad = true;
            this.inputImagePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.inputImagePictureBox_Paint);
            this.inputImagePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inputImagePictureBox_MouseDown);
            this.inputImagePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.inputImagePictureBox_MouseMove);
            this.inputImagePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.inputImagePictureBox_MouseUp);
            // 
            // inputImageDragLabel
            // 
            this.inputImageDragLabel.AutoSize = true;
            this.inputImageDragLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inputImageDragLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inputImageDragLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputImageDragLabel.Location = new System.Drawing.Point(8, 337);
            this.inputImageDragLabel.Name = "inputImageDragLabel";
            this.inputImageDragLabel.Size = new System.Drawing.Size(31, 15);
            this.inputImageDragLabel.TabIndex = 24;
            this.inputImageDragLabel.Text = "D&&D";
            this.inputImageDragLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.inputImageDragLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inputImageDragLabel_MouseDown);
            // 
            // trfmGroupBox
            // 
            this.trfmGroupBox.Controls.Add(this.reverseTrfmButton);
            this.trfmGroupBox.Controls.Add(this.cancelTrfmButton);
            this.trfmGroupBox.Controls.Add(this.resetTrfmButton);
            this.trfmGroupBox.Controls.Add(this.repeatTrfmButton);
            this.trfmGroupBox.Controls.Add(this.lastTrfmTextBox);
            this.trfmGroupBox.Controls.Add(this.label8);
            this.trfmGroupBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trfmGroupBox.Location = new System.Drawing.Point(8, 355);
            this.trfmGroupBox.Name = "trfmGroupBox";
            this.trfmGroupBox.Size = new System.Drawing.Size(256, 103);
            this.trfmGroupBox.TabIndex = 12;
            this.trfmGroupBox.TabStop = false;
            this.trfmGroupBox.Text = "Transformation";
            // 
            // reverseTrfmButton
            // 
            this.reverseTrfmButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.reverseTrfmButton.AutoSize = true;
            this.reverseTrfmButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reverseTrfmButton.Location = new System.Drawing.Point(71, 67);
            this.reverseTrfmButton.Name = "reverseTrfmButton";
            this.reverseTrfmButton.Size = new System.Drawing.Size(60, 24);
            this.reverseTrfmButton.TabIndex = 1;
            this.reverseTrfmButton.Text = "Reverse";
            this.reverseTrfmButton.UseVisualStyleBackColor = true;
            this.reverseTrfmButton.Click += new System.EventHandler(this.reverseTrfmButton_Click);
            // 
            // cancelTrfmButton
            // 
            this.cancelTrfmButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cancelTrfmButton.AutoSize = true;
            this.cancelTrfmButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelTrfmButton.Location = new System.Drawing.Point(137, 67);
            this.cancelTrfmButton.Name = "cancelTrfmButton";
            this.cancelTrfmButton.Size = new System.Drawing.Size(53, 24);
            this.cancelTrfmButton.TabIndex = 2;
            this.cancelTrfmButton.Text = "Cancel";
            this.cancelTrfmButton.UseVisualStyleBackColor = true;
            this.cancelTrfmButton.Click += new System.EventHandler(this.cancelTrfmButton_Click);
            // 
            // resetTrfmButton
            // 
            this.resetTrfmButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.resetTrfmButton.AutoSize = true;
            this.resetTrfmButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetTrfmButton.Location = new System.Drawing.Point(196, 67);
            this.resetTrfmButton.Name = "resetTrfmButton";
            this.resetTrfmButton.Size = new System.Drawing.Size(48, 24);
            this.resetTrfmButton.TabIndex = 3;
            this.resetTrfmButton.Text = "Reset";
            this.resetTrfmButton.UseVisualStyleBackColor = true;
            this.resetTrfmButton.Click += new System.EventHandler(this.resetTrfmButton_Click);
            // 
            // repeatTrfmButton
            // 
            this.repeatTrfmButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.repeatTrfmButton.AutoSize = true;
            this.repeatTrfmButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatTrfmButton.Location = new System.Drawing.Point(9, 67);
            this.repeatTrfmButton.Name = "repeatTrfmButton";
            this.repeatTrfmButton.Size = new System.Drawing.Size(56, 24);
            this.repeatTrfmButton.TabIndex = 0;
            this.repeatTrfmButton.Text = "Repeat";
            this.uiToolTip.SetToolTip(this.repeatTrfmButton, "Use ENTER key to keep pushing the button");
            this.repeatTrfmButton.UseVisualStyleBackColor = true;
            this.repeatTrfmButton.Click += new System.EventHandler(this.repeatTrfmButton_Click);
            // 
            // lastTrfmTextBox
            // 
            this.lastTrfmTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastTrfmTextBox.Location = new System.Drawing.Point(9, 39);
            this.lastTrfmTextBox.Name = "lastTrfmTextBox";
            this.lastTrfmTextBox.ReadOnly = true;
            this.lastTrfmTextBox.ShortcutsEnabled = false;
            this.lastTrfmTextBox.Size = new System.Drawing.Size(178, 22);
            this.lastTrfmTextBox.TabIndex = 2;
            this.lastTrfmTextBox.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 14);
            this.label8.TabIndex = 6;
            this.label8.Text = "Last Action:";
            // 
            // effectGroupBox
            // 
            this.effectGroupBox.Controls.Add(this.clearBGbutton);
            this.effectGroupBox.Controls.Add(this.setBGbutton);
            this.effectGroupBox.Controls.Add(this.changeFontButton);
            this.effectGroupBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.effectGroupBox.Location = new System.Drawing.Point(8, 464);
            this.effectGroupBox.Name = "effectGroupBox";
            this.effectGroupBox.Size = new System.Drawing.Size(256, 63);
            this.effectGroupBox.TabIndex = 13;
            this.effectGroupBox.TabStop = false;
            this.effectGroupBox.Text = "Effect";
            // 
            // clearBGbutton
            // 
            this.clearBGbutton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.clearBGbutton.AutoSize = true;
            this.clearBGbutton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBGbutton.Location = new System.Drawing.Point(157, 26);
            this.clearBGbutton.Name = "clearBGbutton";
            this.clearBGbutton.Size = new System.Drawing.Size(63, 24);
            this.clearBGbutton.TabIndex = 2;
            this.clearBGbutton.Text = "Clear BG";
            this.clearBGbutton.UseVisualStyleBackColor = true;
            this.clearBGbutton.Click += new System.EventHandler(this.clearBGbutton_Click);
            // 
            // setBGbutton
            // 
            this.setBGbutton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.setBGbutton.AutoSize = true;
            this.setBGbutton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setBGbutton.Location = new System.Drawing.Point(99, 26);
            this.setBGbutton.Name = "setBGbutton";
            this.setBGbutton.Size = new System.Drawing.Size(52, 24);
            this.setBGbutton.TabIndex = 1;
            this.setBGbutton.Text = "Set BG";
            this.setBGbutton.UseVisualStyleBackColor = true;
            this.setBGbutton.Click += new System.EventHandler(this.setBGbutton_Click);
            // 
            // changeFontButton
            // 
            this.changeFontButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.changeFontButton.AutoSize = true;
            this.changeFontButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeFontButton.Location = new System.Drawing.Point(9, 26);
            this.changeFontButton.Name = "changeFontButton";
            this.changeFontButton.Size = new System.Drawing.Size(84, 24);
            this.changeFontButton.TabIndex = 0;
            this.changeFontButton.Text = "Change Font";
            this.changeFontButton.UseVisualStyleBackColor = true;
            this.changeFontButton.Click += new System.EventHandler(this.changeFontButton_Click);
            // 
            // spatialPoolerPictureBox
            // 
            this.spatialPoolerPictureBox.BackColor = System.Drawing.Color.White;
            this.spatialPoolerPictureBox.Location = new System.Drawing.Point(7, 26);
            this.spatialPoolerPictureBox.MinimumSize = new System.Drawing.Size(161, 161);
            this.spatialPoolerPictureBox.Name = "spatialPoolerPictureBox";
            this.spatialPoolerPictureBox.Size = new System.Drawing.Size(161, 161);
            this.spatialPoolerPictureBox.TabIndex = 0;
            this.spatialPoolerPictureBox.TabStop = false;
            this.spatialPoolerPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.spatialPoolerPictureBox_Paint);
            this.spatialPoolerPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spatialPoolerPictureBox_MouseDown);
            this.spatialPoolerPictureBox.MouseEnter += new System.EventHandler(this.spatialPoolerPictureBox_MouseEnter);
            this.spatialPoolerPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spatialPoolerPictureBox_MouseMove);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Spatial Pooler:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Active";
            // 
            // activeColumnCountTextBox
            // 
            this.activeColumnCountTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeColumnCountTextBox.Location = new System.Drawing.Point(76, 16);
            this.activeColumnCountTextBox.Name = "activeColumnCountTextBox";
            this.activeColumnCountTextBox.ReadOnly = true;
            this.activeColumnCountTextBox.Size = new System.Drawing.Size(78, 22);
            this.activeColumnCountTextBox.TabIndex = 3;
            this.activeColumnCountTextBox.TabStop = false;
            this.activeColumnCountTextBox.Text = "# (%)";
            this.activeColumnCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiToolTip.SetToolTip(this.activeColumnCountTextBox, "% is the number of active columns in the region");
            // 
            // inputStringFontDialog
            // 
            this.inputStringFontDialog.Font = new System.Drawing.Font("Georgia", 150F);
            // 
            // uiToolTip
            // 
            this.uiToolTip.AutoPopDelay = 20000;
            this.uiToolTip.InitialDelay = 500;
            this.uiToolTip.ReshowDelay = 100;
            this.uiToolTip.ShowAlways = true;
            // 
            // nProximalSynapseTextBox
            // 
            this.nProximalSynapseTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nProximalSynapseTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.nProximalSynapseTextBox.Location = new System.Drawing.Point(84, 21);
            this.nProximalSynapseTextBox.Name = "nProximalSynapseTextBox";
            this.nProximalSynapseTextBox.Size = new System.Drawing.Size(38, 22);
            this.nProximalSynapseTextBox.TabIndex = 0;
            this.nProximalSynapseTextBox.Text = "1024";
            this.nProximalSynapseTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiToolTip.SetToolTip(this.nProximalSynapseTextBox, "The number of the potential synapses of a column");
            this.nProximalSynapseTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nBucSynapseTextBox_KeyPress);
            this.nProximalSynapseTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nBucSynapseTextBox_Validating);
            // 
            // fanoutRadiusTextBox
            // 
            this.fanoutRadiusTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fanoutRadiusTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.fanoutRadiusTextBox.Location = new System.Drawing.Point(84, 50);
            this.fanoutRadiusTextBox.Name = "fanoutRadiusTextBox";
            this.fanoutRadiusTextBox.Size = new System.Drawing.Size(38, 22);
            this.fanoutRadiusTextBox.TabIndex = 1;
            this.fanoutRadiusTextBox.Text = "64";
            this.fanoutRadiusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiToolTip.SetToolTip(this.fanoutRadiusTextBox, "The radius in pixels of the area of input image\r\nthat one column can cover.");
            this.fanoutRadiusTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fanoutRadiusTextBox_KeyPress);
            this.fanoutRadiusTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.fanoutRadiusTextBox_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.permSinkerTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nProximalSynapseTextBox);
            this.groupBox1.Controls.Add(this.spInitButton);
            this.groupBox1.Controls.Add(this.fanoutRadiusTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 78);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proximal Dendrite Synapse";
            this.uiToolTip.SetToolTip(this.groupBox1, "These parameters setup the potential synapses of\r\nthe proximal dendrites and thei" +
        "r synapses of the columns.\r\naka. bottom-up connections from the input layer.");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(134, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 28);
            this.label15.TabIndex = 2;
            this.label15.Text = "Perm\r\n Sinker";
            // 
            // permSinkerTextBox
            // 
            this.permSinkerTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permSinkerTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.permSinkerTextBox.Location = new System.Drawing.Point(184, 21);
            this.permSinkerTextBox.Name = "permSinkerTextBox";
            this.permSinkerTextBox.Size = new System.Drawing.Size(38, 22);
            this.permSinkerTextBox.TabIndex = 2;
            this.permSinkerTextBox.Text = "66";
            this.permSinkerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiToolTip.SetToolTip(this.permSinkerTextBox, resources.GetString("permSinkerTextBox.ToolTip"));
            this.permSinkerTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.permSinkerTextBox_KeyPress);
            this.permSinkerTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.permSinkerTextBox_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "Fanout\r\n  Radius";
            // 
            // spInitButton
            // 
            this.spInitButton.AutoSize = true;
            this.spInitButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spInitButton.Location = new System.Drawing.Point(137, 49);
            this.spInitButton.Name = "spInitButton";
            this.spInitButton.Size = new System.Drawing.Size(80, 24);
            this.spInitButton.TabIndex = 3;
            this.spInitButton.Text = "Reinitialize";
            this.spInitButton.UseVisualStyleBackColor = true;
            this.spInitButton.Click += new System.EventHandler(this.spInitButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Synapse\r\n per Column";
            // 
            // targetSparsityTextBox
            // 
            this.targetSparsityTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetSparsityTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.targetSparsityTextBox.Location = new System.Drawing.Point(70, 29);
            this.targetSparsityTextBox.Name = "targetSparsityTextBox";
            this.targetSparsityTextBox.Size = new System.Drawing.Size(38, 22);
            this.targetSparsityTextBox.TabIndex = 0;
            this.targetSparsityTextBox.Text = "4%";
            this.targetSparsityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiToolTip.SetToolTip(this.targetSparsityTextBox, "% target of the active columns in the region");
            this.targetSparsityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.targetSparcityTextBox_KeyPress);
            this.targetSparsityTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.targetSparcityTextBox_Validating);
            // 
            // minOverlapTextBox
            // 
            this.minOverlapTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minOverlapTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.minOverlapTextBox.Location = new System.Drawing.Point(70, 61);
            this.minOverlapTextBox.Name = "minOverlapTextBox";
            this.minOverlapTextBox.Size = new System.Drawing.Size(38, 22);
            this.minOverlapTextBox.TabIndex = 1;
            this.minOverlapTextBox.Text = "2%";
            this.minOverlapTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiToolTip.SetToolTip(this.minOverlapTextBox, "% threshold of the active bottom-up connects (proximal synapses)\r\nthat can activa" +
        "te a column.  To react the small input image, the\r\nimage size must be larger tha" +
        "n this % within the fanout radius.");
            this.minOverlapTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minOverlapTextBox_KeyPress);
            this.minOverlapTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.minOverlapTextBox_Validating);
            // 
            // spPermSpectrumPictureBox
            // 
            this.spPermSpectrumPictureBox.BackColor = System.Drawing.Color.White;
            this.spPermSpectrumPictureBox.Location = new System.Drawing.Point(174, 42);
            this.spPermSpectrumPictureBox.Name = "spPermSpectrumPictureBox";
            this.spPermSpectrumPictureBox.Size = new System.Drawing.Size(140, 65);
            this.spPermSpectrumPictureBox.TabIndex = 21;
            this.spPermSpectrumPictureBox.TabStop = false;
            this.uiToolTip.SetToolTip(this.spPermSpectrumPictureBox, resources.GetString("spPermSpectrumPictureBox.ToolTip"));
            this.spPermSpectrumPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.spPermSpectrumPictureBox_Paint);
            // 
            // spUnlearnCheckBox
            // 
            this.spUnlearnCheckBox.AutoSize = true;
            this.spUnlearnCheckBox.Enabled = false;
            this.spUnlearnCheckBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spUnlearnCheckBox.Location = new System.Drawing.Point(57, 19);
            this.spUnlearnCheckBox.Name = "spUnlearnCheckBox";
            this.spUnlearnCheckBox.Size = new System.Drawing.Size(79, 18);
            this.spUnlearnCheckBox.TabIndex = 1;
            this.spUnlearnCheckBox.Text = "Forgetting";
            this.uiToolTip.SetToolTip(this.spUnlearnCheckBox, "Reinforce all synapses of chosen columns\r\nwhen target sparsity is not achieved.");
            this.spUnlearnCheckBox.UseVisualStyleBackColor = true;
            this.spUnlearnCheckBox.CheckedChanged += new System.EventHandler(this.spUnlearnCheckBox_CheckedChanged);
            // 
            // spBoostCheckBox
            // 
            this.spBoostCheckBox.AutoSize = true;
            this.spBoostCheckBox.Enabled = false;
            this.spBoostCheckBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spBoostCheckBox.Location = new System.Drawing.Point(57, 36);
            this.spBoostCheckBox.Name = "spBoostCheckBox";
            this.spBoostCheckBox.Size = new System.Drawing.Size(73, 18);
            this.spBoostCheckBox.TabIndex = 2;
            this.spBoostCheckBox.Text = "Boosting";
            this.uiToolTip.SetToolTip(this.spBoostCheckBox, "Boost the intensity of \"often losers\" columns");
            this.spBoostCheckBox.UseVisualStyleBackColor = true;
            // 
            // spLearningCheckBox
            // 
            this.spLearningCheckBox.AutoSize = true;
            this.spLearningCheckBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spLearningCheckBox.Location = new System.Drawing.Point(10, 19);
            this.spLearningCheckBox.Name = "spLearningCheckBox";
            this.spLearningCheckBox.Size = new System.Drawing.Size(41, 18);
            this.spLearningCheckBox.TabIndex = 0;
            this.spLearningCheckBox.Text = "On";
            this.uiToolTip.SetToolTip(this.spLearningCheckBox, "Reinforce the synapse of the active columns");
            this.spLearningCheckBox.UseVisualStyleBackColor = true;
            this.spLearningCheckBox.CheckedChanged += new System.EventHandler(this.spLearningCheckBox_CheckedChanged);
            // 
            // inhibitionPenaltyTextBox
            // 
            this.inhibitionPenaltyTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inhibitionPenaltyTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.inhibitionPenaltyTextBox.Location = new System.Drawing.Point(193, 61);
            this.inhibitionPenaltyTextBox.Name = "inhibitionPenaltyTextBox";
            this.inhibitionPenaltyTextBox.Size = new System.Drawing.Size(38, 22);
            this.inhibitionPenaltyTextBox.TabIndex = 3;
            this.inhibitionPenaltyTextBox.Text = "8%";
            this.inhibitionPenaltyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiToolTip.SetToolTip(this.inhibitionPenaltyTextBox, "% threshold of the active bottom-up connects (proximal synapses)\r\nthat can activa" +
        "te a column.  To react the small input image, the\r\nimage size must be larger tha" +
        "n this % within the fanout radius.");
            this.inhibitionPenaltyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inhibitionPenaltyTextBox_KeyPress);
            this.inhibitionPenaltyTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.inhibitionPenaltyTextBox_Validating);
            // 
            // inhibitedColumnCountTextBox
            // 
            this.inhibitedColumnCountTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inhibitedColumnCountTextBox.Location = new System.Drawing.Point(76, 44);
            this.inhibitedColumnCountTextBox.Name = "inhibitedColumnCountTextBox";
            this.inhibitedColumnCountTextBox.ReadOnly = true;
            this.inhibitedColumnCountTextBox.Size = new System.Drawing.Size(78, 22);
            this.inhibitedColumnCountTextBox.TabIndex = 5;
            this.inhibitedColumnCountTextBox.TabStop = false;
            this.inhibitedColumnCountTextBox.Text = "# (%)";
            this.inhibitedColumnCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiToolTip.SetToolTip(this.inhibitedColumnCountTextBox, "% is the number of inhibited columns / the number of preactive columns");
            // 
            // unlearnColumnTextBox
            // 
            this.unlearnColumnTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unlearnColumnTextBox.Location = new System.Drawing.Point(76, 72);
            this.unlearnColumnTextBox.Name = "unlearnColumnTextBox";
            this.unlearnColumnTextBox.ReadOnly = true;
            this.unlearnColumnTextBox.Size = new System.Drawing.Size(78, 22);
            this.unlearnColumnTextBox.TabIndex = 16;
            this.unlearnColumnTextBox.TabStop = false;
            this.unlearnColumnTextBox.Text = "# (%)";
            this.unlearnColumnTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiToolTip.SetToolTip(this.unlearnColumnTextBox, "% is the number of unlearning columns in the region");
            // 
            // inhibitionRadiusTextBox
            // 
            this.inhibitionRadiusTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inhibitionRadiusTextBox.Location = new System.Drawing.Point(73, 172);
            this.inhibitionRadiusTextBox.Name = "inhibitionRadiusTextBox";
            this.inhibitionRadiusTextBox.ReadOnly = true;
            this.inhibitionRadiusTextBox.Size = new System.Drawing.Size(56, 22);
            this.inhibitionRadiusTextBox.TabIndex = 18;
            this.inhibitionRadiusTextBox.TabStop = false;
            this.inhibitionRadiusTextBox.Text = "#";
            this.inhibitionRadiusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiToolTip.SetToolTip(this.inhibitionRadiusTextBox, "% is the number of unlearning columns in the region");
            // 
            // underSparsityORTextBox
            // 
            this.underSparsityORTextBox.Enabled = false;
            this.underSparsityORTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.underSparsityORTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.underSparsityORTextBox.Location = new System.Drawing.Point(99, 60);
            this.underSparsityORTextBox.Name = "underSparsityORTextBox";
            this.underSparsityORTextBox.Size = new System.Drawing.Size(38, 22);
            this.underSparsityORTextBox.TabIndex = 3;
            this.underSparsityORTextBox.Text = "110%";
            this.underSparsityORTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiToolTip.SetToolTip(this.underSparsityORTextBox, "If the number of active columns go below the target sparsity,\r\nup to (the target " +
        "number of the active columns) * this value will\r\nunlearn the input patterns.");
            this.underSparsityORTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.underSparsityORTextBox_KeyPress);
            this.underSparsityORTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.underSparsityORTextBox_Validating);
            // 
            // spLabelCapacityTextBox
            // 
            this.spLabelCapacityTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spLabelCapacityTextBox.Location = new System.Drawing.Point(52, 262);
            this.spLabelCapacityTextBox.Multiline = true;
            this.spLabelCapacityTextBox.Name = "spLabelCapacityTextBox";
            this.spLabelCapacityTextBox.ReadOnly = true;
            this.spLabelCapacityTextBox.Size = new System.Drawing.Size(111, 50);
            this.spLabelCapacityTextBox.TabIndex = 22;
            this.spLabelCapacityTextBox.TabStop = false;
            this.spLabelCapacityTextBox.Text = "Min: # (%)\r\nAve: # (%)\r\nMax: # (%)";
            this.spLabelCapacityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uiToolTip.SetToolTip(this.spLabelCapacityTextBox, "% is the number of active columns in the region");
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Controls.Add(this.reverseMapPictureBox);
            this.flowLayoutPanel2.Controls.Add(this.reverseMapDragLabel);
            this.flowLayoutPanel2.Controls.Add(this.spControlGroupBox);
            this.flowLayoutPanel2.Controls.Add(this.spStatsGroupBox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(750, 542);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.spPictureBoxConnectedSynapseRadioButton);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.spPictureBoxBoostRadioButton);
            this.panel1.Controls.Add(this.spPermSpectrumPictureBox);
            this.panel1.Controls.Add(this.spStatusLabel);
            this.panel1.Controls.Add(this.spPictureBoxDutyCycleRadioButton);
            this.panel1.Controls.Add(this.permanenceSpectralDragLabel);
            this.panel1.Controls.Add(this.spatialPoolerDragLabel);
            this.panel1.Controls.Add(this.spatialPoolerPictureBox);
            this.panel1.Controls.Add(this.spPictureBoxIntensityRadioButton);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 213);
            this.panel1.TabIndex = 2;
            // 
            // spPictureBoxConnectedSynapseRadioButton
            // 
            this.spPictureBoxConnectedSynapseRadioButton.AutoSize = true;
            this.spPictureBoxConnectedSynapseRadioButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spPictureBoxConnectedSynapseRadioButton.Location = new System.Drawing.Point(176, 147);
            this.spPictureBoxConnectedSynapseRadioButton.Name = "spPictureBoxConnectedSynapseRadioButton";
            this.spPictureBoxConnectedSynapseRadioButton.Size = new System.Drawing.Size(136, 18);
            this.spPictureBoxConnectedSynapseRadioButton.TabIndex = 1;
            this.spPictureBoxConnectedSynapseRadioButton.Text = "Connected Synapses";
            this.spPictureBoxConnectedSynapseRadioButton.UseVisualStyleBackColor = true;
            this.spPictureBoxConnectedSynapseRadioButton.CheckedChanged += new System.EventHandler(this.spPictureBoxConnectedSynapseRadioButton_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(171, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 14);
            this.label12.TabIndex = 4;
            this.label12.Text = "Permanence Spectrum";
            // 
            // spPictureBoxBoostRadioButton
            // 
            this.spPictureBoxBoostRadioButton.AutoSize = true;
            this.spPictureBoxBoostRadioButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spPictureBoxBoostRadioButton.Location = new System.Drawing.Point(176, 164);
            this.spPictureBoxBoostRadioButton.Name = "spPictureBoxBoostRadioButton";
            this.spPictureBoxBoostRadioButton.Size = new System.Drawing.Size(56, 18);
            this.spPictureBoxBoostRadioButton.TabIndex = 2;
            this.spPictureBoxBoostRadioButton.Text = "Boost";
            this.spPictureBoxBoostRadioButton.UseVisualStyleBackColor = true;
            this.spPictureBoxBoostRadioButton.CheckedChanged += new System.EventHandler(this.spPictureBoxBoostRadioButton_CheckedChanged);
            // 
            // spStatusLabel
            // 
            this.spStatusLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spStatusLabel.Location = new System.Drawing.Point(44, 190);
            this.spStatusLabel.Name = "spStatusLabel";
            this.spStatusLabel.Size = new System.Drawing.Size(124, 19);
            this.spStatusLabel.TabIndex = 20;
            // 
            // spPictureBoxDutyCycleRadioButton
            // 
            this.spPictureBoxDutyCycleRadioButton.AutoSize = true;
            this.spPictureBoxDutyCycleRadioButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spPictureBoxDutyCycleRadioButton.Location = new System.Drawing.Point(176, 181);
            this.spPictureBoxDutyCycleRadioButton.Name = "spPictureBoxDutyCycleRadioButton";
            this.spPictureBoxDutyCycleRadioButton.Size = new System.Drawing.Size(111, 18);
            this.spPictureBoxDutyCycleRadioButton.TabIndex = 3;
            this.spPictureBoxDutyCycleRadioButton.Text = "Activation Count";
            this.spPictureBoxDutyCycleRadioButton.UseVisualStyleBackColor = true;
            this.spPictureBoxDutyCycleRadioButton.CheckedChanged += new System.EventHandler(this.spPictureBoxDutyCycleRadioButton_CheckedChanged);
            // 
            // permanenceSpectralDragLabel
            // 
            this.permanenceSpectralDragLabel.AutoSize = true;
            this.permanenceSpectralDragLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.permanenceSpectralDragLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.permanenceSpectralDragLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permanenceSpectralDragLabel.Location = new System.Drawing.Point(174, 110);
            this.permanenceSpectralDragLabel.Name = "permanenceSpectralDragLabel";
            this.permanenceSpectralDragLabel.Size = new System.Drawing.Size(31, 15);
            this.permanenceSpectralDragLabel.TabIndex = 0;
            this.permanenceSpectralDragLabel.Text = "D&&D";
            this.permanenceSpectralDragLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.permanenceSpectralDragLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.permanenceSpectralDragLabel_MouseDown);
            // 
            // spatialPoolerDragLabel
            // 
            this.spatialPoolerDragLabel.AutoSize = true;
            this.spatialPoolerDragLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spatialPoolerDragLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spatialPoolerDragLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spatialPoolerDragLabel.Location = new System.Drawing.Point(7, 190);
            this.spatialPoolerDragLabel.Name = "spatialPoolerDragLabel";
            this.spatialPoolerDragLabel.Size = new System.Drawing.Size(31, 15);
            this.spatialPoolerDragLabel.TabIndex = 25;
            this.spatialPoolerDragLabel.Text = "D&&D";
            this.spatialPoolerDragLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.spatialPoolerDragLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spatialPoolerDragLabel_MouseDown);
            // 
            // spPictureBoxIntensityRadioButton
            // 
            this.spPictureBoxIntensityRadioButton.AutoSize = true;
            this.spPictureBoxIntensityRadioButton.Checked = true;
            this.spPictureBoxIntensityRadioButton.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spPictureBoxIntensityRadioButton.Location = new System.Drawing.Point(176, 130);
            this.spPictureBoxIntensityRadioButton.Name = "spPictureBoxIntensityRadioButton";
            this.spPictureBoxIntensityRadioButton.Size = new System.Drawing.Size(97, 18);
            this.spPictureBoxIntensityRadioButton.TabIndex = 0;
            this.spPictureBoxIntensityRadioButton.TabStop = true;
            this.spPictureBoxIntensityRadioButton.Text = "Column State";
            this.spPictureBoxIntensityRadioButton.UseVisualStyleBackColor = true;
            this.spPictureBoxIntensityRadioButton.CheckedChanged += new System.EventHandler(this.spPictureBoxIntensityRadioButton_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(214, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Reverse Map && Reconstruction:";
            // 
            // reverseMapPictureBox
            // 
            this.reverseMapPictureBox.BackColor = System.Drawing.Color.Black;
            this.reverseMapPictureBox.Location = new System.Drawing.Point(8, 246);
            this.reverseMapPictureBox.Name = "reverseMapPictureBox";
            this.reverseMapPictureBox.Size = new System.Drawing.Size(256, 256);
            this.reverseMapPictureBox.TabIndex = 14;
            this.reverseMapPictureBox.TabStop = false;
            this.reverseMapPictureBox.WaitOnLoad = true;
            this.reverseMapPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.reverseMapPictureBox_Paint);
            // 
            // reverseMapDragLabel
            // 
            this.reverseMapDragLabel.AutoSize = true;
            this.reverseMapDragLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reverseMapDragLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reverseMapDragLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reverseMapDragLabel.Location = new System.Drawing.Point(8, 505);
            this.reverseMapDragLabel.Name = "reverseMapDragLabel";
            this.reverseMapDragLabel.Size = new System.Drawing.Size(31, 15);
            this.reverseMapDragLabel.TabIndex = 26;
            this.reverseMapDragLabel.Text = "D&&D";
            this.reverseMapDragLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.reverseMapDragLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.reverseMapDragLabel_MouseDown);
            // 
            // spControlGroupBox
            // 
            this.spControlGroupBox.Controls.Add(this.groupBox3);
            this.spControlGroupBox.Controls.Add(this.inhibitionPenaltyTextBox);
            this.spControlGroupBox.Controls.Add(this.label21);
            this.spControlGroupBox.Controls.Add(this.minOverlapTextBox);
            this.spControlGroupBox.Controls.Add(this.label11);
            this.spControlGroupBox.Controls.Add(this.label10);
            this.spControlGroupBox.Controls.Add(this.targetSparsityTextBox);
            this.spControlGroupBox.Controls.Add(this.groupBox1);
            this.spControlGroupBox.Controls.Add(this.spLocalInhibitionCheckBox);
            this.spControlGroupBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spControlGroupBox.Location = new System.Drawing.Point(334, 8);
            this.spControlGroupBox.Name = "spControlGroupBox";
            this.spControlGroupBox.Size = new System.Drawing.Size(408, 187);
            this.spControlGroupBox.TabIndex = 3;
            this.spControlGroupBox.TabStop = false;
            this.spControlGroupBox.Text = "Control";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.spLearningCheckBox);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.spUnlearnCheckBox);
            this.groupBox3.Controls.Add(this.underSparsityORTextBox);
            this.groupBox3.Controls.Add(this.spBoostCheckBox);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(248, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(149, 88);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Learning";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 54);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 28);
            this.label18.TabIndex = 29;
            this.label18.Text = "Under-sparsity\r\n  Overreaction";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(126, 55);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 28);
            this.label21.TabIndex = 25;
            this.label21.Text = "Inhibition\r\nPenalty";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 28);
            this.label11.TabIndex = 21;
            this.label11.Text = "Minimum\r\n  Overlap";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 28);
            this.label10.TabIndex = 19;
            this.label10.Text = "Target\r\n Sparsity";
            // 
            // spLocalInhibitionCheckBox
            // 
            this.spLocalInhibitionCheckBox.AutoSize = true;
            this.spLocalInhibitionCheckBox.Checked = true;
            this.spLocalInhibitionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.spLocalInhibitionCheckBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spLocalInhibitionCheckBox.Location = new System.Drawing.Point(120, 34);
            this.spLocalInhibitionCheckBox.Name = "spLocalInhibitionCheckBox";
            this.spLocalInhibitionCheckBox.Size = new System.Drawing.Size(111, 18);
            this.spLocalInhibitionCheckBox.TabIndex = 2;
            this.spLocalInhibitionCheckBox.Text = "Local Inhibition";
            this.spLocalInhibitionCheckBox.UseVisualStyleBackColor = true;
            this.spLocalInhibitionCheckBox.CheckedChanged += new System.EventHandler(this.spLocalInhibitionCheckBox_CheckedChanged);
            // 
            // spStatsGroupBox
            // 
            this.spStatsGroupBox.Controls.Add(this.groupBox4);
            this.spStatsGroupBox.Controls.Add(this.spLabelCapacityTextBox);
            this.spStatsGroupBox.Controls.Add(this.label20);
            this.spStatsGroupBox.Controls.Add(this.label19);
            this.spStatsGroupBox.Controls.Add(this.spLabelInferenceListBox);
            this.spStatsGroupBox.Controls.Add(this.inhibitionRadiusTextBox);
            this.spStatsGroupBox.Controls.Add(this.label27);
            this.spStatsGroupBox.Controls.Add(this.groupBox2);
            this.spStatsGroupBox.Controls.Add(this.connectedSynapseTextBox);
            this.spStatsGroupBox.Controls.Add(this.label14);
            this.spStatsGroupBox.Controls.Add(this.clockStepTextBox);
            this.spStatsGroupBox.Controls.Add(this.label2);
            this.spStatsGroupBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spStatsGroupBox.Location = new System.Drawing.Point(334, 201);
            this.spStatsGroupBox.Name = "spStatsGroupBox";
            this.spStatsGroupBox.Size = new System.Drawing.Size(408, 324);
            this.spStatsGroupBox.TabIndex = 6;
            this.spStatsGroupBox.TabStop = false;
            this.spStatsGroupBox.Text = "Statistics";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.activeColumnCountTextBox);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.inhibitedColumnCountTextBox);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.unlearnColumnTextBox);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(9, 57);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(166, 101);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Column Count";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 14);
            this.label13.TabIndex = 4;
            this.label13.Text = "Inhibited";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(6, 75);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 14);
            this.label25.TabIndex = 15;
            this.label25.Text = "Unlearning";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 262);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 28);
            this.label20.TabIndex = 21;
            this.label20.Text = "Label\r\n Table";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(190, 166);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 14);
            this.label19.TabIndex = 20;
            this.label19.Text = "Active Column Poll";
            // 
            // spLabelInferenceListBox
            // 
            this.spLabelInferenceListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spLabelInferenceListBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spLabelInferenceListBox.FormattingEnabled = true;
            this.spLabelInferenceListBox.ItemHeight = 14;
            this.spLabelInferenceListBox.Items.AddRange(new object[] {
            "32% \"R\" (+5,-1) theta 5",
            "14% \"R\" (+3,-1) theta 2",
            "27% others",
            "10% uncertain"});
            this.spLabelInferenceListBox.Location = new System.Drawing.Point(193, 184);
            this.spLabelInferenceListBox.Name = "spLabelInferenceListBox";
            this.spLabelInferenceListBox.ScrollAlwaysVisible = true;
            this.spLabelInferenceListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.spLabelInferenceListBox.Size = new System.Drawing.Size(188, 128);
            this.spLabelInferenceListBox.TabIndex = 26;
            this.spLabelInferenceListBox.TabStop = false;
            this.uiToolTip.SetToolTip(this.spLabelInferenceListBox, "The left column is the number of votes.\r\nAns: means the correct label of this ima" +
        "ge.");
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(6, 166);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(61, 28);
            this.label27.TabIndex = 17;
            this.label27.Text = "Inhibition\r\n Radius";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spTotalTimeTextBox);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.spLearningTimeTextBox);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.spInhibitionTimeTextBox);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.spOverlapTimeTextBox);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(193, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 123);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SP Elapsed Time";
            // 
            // spTotalTimeTextBox
            // 
            this.spTotalTimeTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spTotalTimeTextBox.Location = new System.Drawing.Point(73, 91);
            this.spTotalTimeTextBox.Name = "spTotalTimeTextBox";
            this.spTotalTimeTextBox.ReadOnly = true;
            this.spTotalTimeTextBox.Size = new System.Drawing.Size(77, 26);
            this.spTotalTimeTextBox.TabIndex = 17;
            this.spTotalTimeTextBox.TabStop = false;
            this.spTotalTimeTextBox.Text = "ms";
            this.spTotalTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(29, 94);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(38, 18);
            this.label26.TabIndex = 16;
            this.label26.Text = "Total";
            // 
            // spLearningTimeTextBox
            // 
            this.spLearningTimeTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spLearningTimeTextBox.Location = new System.Drawing.Point(73, 66);
            this.spLearningTimeTextBox.Name = "spLearningTimeTextBox";
            this.spLearningTimeTextBox.ReadOnly = true;
            this.spLearningTimeTextBox.Size = new System.Drawing.Size(77, 22);
            this.spLearningTimeTextBox.TabIndex = 15;
            this.spLearningTimeTextBox.TabStop = false;
            this.spLearningTimeTextBox.Text = "ms";
            this.spLearningTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(13, 69);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 14);
            this.label24.TabIndex = 14;
            this.label24.Text = "Learning";
            // 
            // spInhibitionTimeTextBox
            // 
            this.spInhibitionTimeTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spInhibitionTimeTextBox.Location = new System.Drawing.Point(73, 42);
            this.spInhibitionTimeTextBox.Name = "spInhibitionTimeTextBox";
            this.spInhibitionTimeTextBox.ReadOnly = true;
            this.spInhibitionTimeTextBox.Size = new System.Drawing.Size(77, 22);
            this.spInhibitionTimeTextBox.TabIndex = 13;
            this.spInhibitionTimeTextBox.TabStop = false;
            this.spInhibitionTimeTextBox.Text = "ms";
            this.spInhibitionTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(18, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 14);
            this.label16.TabIndex = 10;
            this.label16.Text = "Overlap";
            // 
            // spOverlapTimeTextBox
            // 
            this.spOverlapTimeTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spOverlapTimeTextBox.Location = new System.Drawing.Point(73, 17);
            this.spOverlapTimeTextBox.Name = "spOverlapTimeTextBox";
            this.spOverlapTimeTextBox.ReadOnly = true;
            this.spOverlapTimeTextBox.Size = new System.Drawing.Size(77, 22);
            this.spOverlapTimeTextBox.TabIndex = 11;
            this.spOverlapTimeTextBox.TabStop = false;
            this.spOverlapTimeTextBox.Text = "ms";
            this.spOverlapTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 14);
            this.label17.TabIndex = 12;
            this.label17.Text = "Inhibition";
            // 
            // connectedSynapseTextBox
            // 
            this.connectedSynapseTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectedSynapseTextBox.Location = new System.Drawing.Point(73, 206);
            this.connectedSynapseTextBox.Multiline = true;
            this.connectedSynapseTextBox.Name = "connectedSynapseTextBox";
            this.connectedSynapseTextBox.ReadOnly = true;
            this.connectedSynapseTextBox.Size = new System.Drawing.Size(102, 50);
            this.connectedSynapseTextBox.TabIndex = 9;
            this.connectedSynapseTextBox.TabStop = false;
            this.connectedSynapseTextBox.Text = "Min: # (%)\r\nAve: # (%)\r\nMax: # (%)";
            this.connectedSynapseTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.connectedSynapseTextBox.WordWrap = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 206);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 28);
            this.label14.TabIndex = 8;
            this.label14.Text = "Connected\r\n Synapses";
            // 
            // clockStepTextBox
            // 
            this.clockStepTextBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockStepTextBox.Location = new System.Drawing.Point(52, 27);
            this.clockStepTextBox.Name = "clockStepTextBox";
            this.clockStepTextBox.ReadOnly = true;
            this.clockStepTextBox.Size = new System.Drawing.Size(56, 22);
            this.clockStepTextBox.TabIndex = 7;
            this.clockStepTextBox.TabStop = false;
            this.clockStepTextBox.Text = "N/A";
            this.clockStepTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Clock\r\n Ticks";
            // 
            // inputImageBGFileDialog
            // 
            this.inputImageBGFileDialog.Filter = "image file|*.png;*.jpg;*.gif;*.bmp|any file|*.*";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(1034, 542);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 8;
            this.splitContainer1.TabStop = false;
            // 
            // spatialPoolerToolTip
            // 
            this.spatialPoolerToolTip.AutoPopDelay = 25000;
            this.spatialPoolerToolTip.InitialDelay = 100;
            this.spatialPoolerToolTip.ReshowDelay = 100;
            // 
            // spInitBackgroundWorker
            // 
            this.spInitBackgroundWorker.WorkerReportsProgress = true;
            this.spInitBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.spInitBackgroundWorker_DoWork);
            this.spInitBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.spInitBackgroundWorker_ProgressChanged);
            this.spInitBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.spInitBackgroundWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 542);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "HTM CLA Experiment1";
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputImagePictureBox)).EndInit();
            this.trfmGroupBox.ResumeLayout(false);
            this.trfmGroupBox.PerformLayout();
            this.effectGroupBox.ResumeLayout(false);
            this.effectGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spatialPoolerPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPermSpectrumPictureBox)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reverseMapPictureBox)).EndInit();
            this.spControlGroupBox.ResumeLayout(false);
            this.spControlGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.spStatsGroupBox.ResumeLayout(false);
            this.spStatsGroupBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputWordTextBox;
        private System.Windows.Forms.PictureBox inputImagePictureBox;
        private System.Windows.Forms.PictureBox spatialPoolerPictureBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox activeColumnCountTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lastTrfmTextBox;
        private System.Windows.Forms.Button repeatTrfmButton;
        private System.Windows.Forms.FontDialog inputStringFontDialog;
        private System.Windows.Forms.Button changeFontButton;
        private System.Windows.Forms.Button resetTrfmButton;
        private System.Windows.Forms.ToolTip uiToolTip;
        private System.Windows.Forms.GroupBox trfmGroupBox;
        private System.Windows.Forms.GroupBox effectGroupBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox spStatsGroupBox;
        private System.Windows.Forms.CheckBox spLearningCheckBox;
        private System.Windows.Forms.Button spInitButton;
        private System.Windows.Forms.GroupBox spControlGroupBox;
        private System.Windows.Forms.Button setBGbutton;
        private System.Windows.Forms.OpenFileDialog inputImageBGFileDialog;
        private System.Windows.Forms.Button clearBGbutton;
        private System.Windows.Forms.Button cancelTrfmButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip spatialPoolerToolTip;
        private System.Windows.Forms.CheckBox spLocalInhibitionCheckBox;
        private System.Windows.Forms.TextBox fanoutRadiusTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox reverseMapPictureBox;
        private System.ComponentModel.BackgroundWorker spInitBackgroundWorker;
        private System.Windows.Forms.TextBox nProximalSynapseTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox targetSparsityTextBox;
        private System.Windows.Forms.TextBox minOverlapTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton spPictureBoxDutyCycleRadioButton;
        private System.Windows.Forms.RadioButton spPictureBoxIntensityRadioButton;
        private System.Windows.Forms.Label spStatusLabel;
        private System.Windows.Forms.Button reverseTrfmButton;
        private System.Windows.Forms.PictureBox spPermSpectrumPictureBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton spPictureBoxBoostRadioButton;
        private System.Windows.Forms.RadioButton spPictureBoxConnectedSynapseRadioButton;
        private System.Windows.Forms.TextBox inhibitedColumnCountTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox spBoostCheckBox;
        private System.Windows.Forms.CheckBox spUnlearnCheckBox;
        private System.Windows.Forms.TextBox connectedSynapseTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox clockStepTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox permSinkerTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox spOverlapTimeTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label inputImageDragLabel;
        private System.Windows.Forms.Label permanenceSpectralDragLabel;
        private System.Windows.Forms.Label spatialPoolerDragLabel;
        private System.Windows.Forms.Label reverseMapDragLabel;
        private System.Windows.Forms.TextBox inhibitionPenaltyTextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox spLearningTimeTextBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox spInhibitionTimeTextBox;
        private System.Windows.Forms.TextBox unlearnColumnTextBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox spTotalTimeTextBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox inhibitionRadiusTextBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox underSparsityORTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ListBox spLabelInferenceListBox;
        private System.Windows.Forms.TextBox spLabelCapacityTextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox4;

    }
}

