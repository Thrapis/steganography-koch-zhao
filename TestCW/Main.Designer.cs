
namespace TestCW
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Image_PictureBox = new System.Windows.Forms.PictureBox();
            this.TextToEncode = new System.Windows.Forms.TextBox();
            this.Key_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.P1X = new System.Windows.Forms.TrackBar();
            this.P1Y = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.P2X = new System.Windows.Forms.TrackBar();
            this.P2Y = new System.Windows.Forms.TrackBar();
            this.Offset_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Spectrum_ComboBox = new System.Windows.Forms.ComboBox();
            this.AnalysedImage_PictureBox = new System.Windows.Forms.PictureBox();
            this.LogPanel = new System.Windows.Forms.TextBox();
            this.Resize_CheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveEncodedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDecodedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAnalisedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseEncodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextToDecode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.EncodedImage_PictureBox = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ProgressBarText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Image_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Key_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Offset_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnalysedImage_PictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EncodedImage_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Image_PictureBox
            // 
            this.Image_PictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Image_PictureBox.BackgroundImage")));
            this.Image_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Image_PictureBox.Location = new System.Drawing.Point(371, 63);
            this.Image_PictureBox.Name = "Image_PictureBox";
            this.Image_PictureBox.Size = new System.Drawing.Size(308, 408);
            this.Image_PictureBox.TabIndex = 0;
            this.Image_PictureBox.TabStop = false;
            this.Image_PictureBox.Click += new System.EventHandler(this.Image_PictureBox_Click);
            // 
            // TextToEncode
            // 
            this.TextToEncode.Location = new System.Drawing.Point(373, 504);
            this.TextToEncode.Multiline = true;
            this.TextToEncode.Name = "TextToEncode";
            this.TextToEncode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextToEncode.Size = new System.Drawing.Size(456, 203);
            this.TextToEncode.TabIndex = 2;
            this.TextToEncode.TextChanged += new System.EventHandler(this.PropertiesChanged);
            this.TextToEncode.DoubleClick += new System.EventHandler(this.OpenText_MenuItem_Click);
            // 
            // Key_NumericUpDown
            // 
            this.Key_NumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Key_NumericUpDown.Location = new System.Drawing.Point(195, 446);
            this.Key_NumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Key_NumericUpDown.Name = "Key_NumericUpDown";
            this.Key_NumericUpDown.Size = new System.Drawing.Size(135, 26);
            this.Key_NumericUpDown.TabIndex = 5;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(10, 723);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(1303, 35);
            this.ProgressBar.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(77, 623);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "P1 = [3, 4]";
            // 
            // P1X
            // 
            this.P1X.LargeChange = 1;
            this.P1X.Location = new System.Drawing.Point(71, 657);
            this.P1X.Maximum = 7;
            this.P1X.Name = "P1X";
            this.P1X.Size = new System.Drawing.Size(104, 56);
            this.P1X.TabIndex = 11;
            this.P1X.Value = 4;
            this.P1X.Scroll += new System.EventHandler(this.PropertiesChanged);
            // 
            // P1Y
            // 
            this.P1Y.LargeChange = 1;
            this.P1Y.Location = new System.Drawing.Point(10, 609);
            this.P1Y.Maximum = 7;
            this.P1Y.Name = "P1Y";
            this.P1Y.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.P1Y.Size = new System.Drawing.Size(56, 104);
            this.P1Y.TabIndex = 10;
            this.P1Y.Value = 3;
            this.P1Y.Scroll += new System.EventHandler(this.PropertiesChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(269, 623);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "P2 = [4, 3]";
            // 
            // P2X
            // 
            this.P2X.LargeChange = 1;
            this.P2X.Location = new System.Drawing.Point(263, 657);
            this.P2X.Maximum = 7;
            this.P2X.Name = "P2X";
            this.P2X.Size = new System.Drawing.Size(104, 56);
            this.P2X.TabIndex = 14;
            this.P2X.Value = 3;
            this.P2X.Scroll += new System.EventHandler(this.PropertiesChanged);
            // 
            // P2Y
            // 
            this.P2Y.LargeChange = 1;
            this.P2Y.Location = new System.Drawing.Point(201, 609);
            this.P2Y.Maximum = 7;
            this.P2Y.Name = "P2Y";
            this.P2Y.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.P2Y.Size = new System.Drawing.Size(56, 104);
            this.P2Y.TabIndex = 13;
            this.P2Y.Value = 4;
            this.P2Y.Scroll += new System.EventHandler(this.PropertiesChanged);
            // 
            // Offset_NumericUpDown
            // 
            this.Offset_NumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Offset_NumericUpDown.Location = new System.Drawing.Point(10, 507);
            this.Offset_NumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Offset_NumericUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.Offset_NumericUpDown.Name = "Offset_NumericUpDown";
            this.Offset_NumericUpDown.Size = new System.Drawing.Size(176, 26);
            this.Offset_NumericUpDown.TabIndex = 16;
            this.Offset_NumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Offset_NumericUpDown.ValueChanged += new System.EventHandler(this.PropertiesChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(191, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Key (bytes)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(6, 484);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Offset";
            // 
            // Spectrum_ComboBox
            // 
            this.Spectrum_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Spectrum_ComboBox.FormattingEnabled = true;
            this.Spectrum_ComboBox.Location = new System.Drawing.Point(209, 507);
            this.Spectrum_ComboBox.Name = "Spectrum_ComboBox";
            this.Spectrum_ComboBox.Size = new System.Drawing.Size(121, 28);
            this.Spectrum_ComboBox.TabIndex = 19;
            this.Spectrum_ComboBox.SelectedIndexChanged += new System.EventHandler(this.PropertiesChanged);
            // 
            // AnalysedImage_PictureBox
            // 
            this.AnalysedImage_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnalysedImage_PictureBox.Location = new System.Drawing.Point(1005, 63);
            this.AnalysedImage_PictureBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.AnalysedImage_PictureBox.Name = "AnalysedImage_PictureBox";
            this.AnalysedImage_PictureBox.Size = new System.Drawing.Size(308, 408);
            this.AnalysedImage_PictureBox.TabIndex = 20;
            this.AnalysedImage_PictureBox.TabStop = false;
            // 
            // LogPanel
            // 
            this.LogPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.LogPanel.Location = new System.Drawing.Point(10, 63);
            this.LogPanel.Multiline = true;
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.ReadOnly = true;
            this.LogPanel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogPanel.Size = new System.Drawing.Size(320, 347);
            this.LogPanel.TabIndex = 22;
            // 
            // Resize_CheckBox
            // 
            this.Resize_CheckBox.AutoSize = true;
            this.Resize_CheckBox.Checked = true;
            this.Resize_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Resize_CheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Resize_CheckBox.Location = new System.Drawing.Point(10, 447);
            this.Resize_CheckBox.Name = "Resize_CheckBox";
            this.Resize_CheckBox.Size = new System.Drawing.Size(150, 24);
            this.Resize_CheckBox.TabIndex = 23;
            this.Resize_CheckBox.Text = "Resize For Text";
            this.Resize_CheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(205, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Spectrum";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1325, 28);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.openTextToolStripMenuItem,
            this.saveEncodedImageToolStripMenuItem,
            this.saveDecodedTextToolStripMenuItem,
            this.saveAnalisedImageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.openImageToolStripMenuItem.Text = "Open image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.OpenImage_MenuItem_Click);
            // 
            // openTextToolStripMenuItem
            // 
            this.openTextToolStripMenuItem.Name = "openTextToolStripMenuItem";
            this.openTextToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.openTextToolStripMenuItem.Text = "Open text";
            this.openTextToolStripMenuItem.Click += new System.EventHandler(this.OpenText_MenuItem_Click);
            // 
            // saveEncodedImageToolStripMenuItem
            // 
            this.saveEncodedImageToolStripMenuItem.Name = "saveEncodedImageToolStripMenuItem";
            this.saveEncodedImageToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.saveEncodedImageToolStripMenuItem.Text = "Save encoded image";
            this.saveEncodedImageToolStripMenuItem.Click += new System.EventHandler(this.SaveEncodedImage_MenuItem_Click);
            // 
            // saveDecodedTextToolStripMenuItem
            // 
            this.saveDecodedTextToolStripMenuItem.Name = "saveDecodedTextToolStripMenuItem";
            this.saveDecodedTextToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.saveDecodedTextToolStripMenuItem.Text = "Save decoded text";
            this.saveDecodedTextToolStripMenuItem.Click += new System.EventHandler(this.SaveDecodedText_MenuItem_Click);
            // 
            // saveAnalisedImageToolStripMenuItem
            // 
            this.saveAnalisedImageToolStripMenuItem.Name = "saveAnalisedImageToolStripMenuItem";
            this.saveAnalisedImageToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.saveAnalisedImageToolStripMenuItem.Text = "Save analyzed image";
            this.saveAnalisedImageToolStripMenuItem.Click += new System.EventHandler(this.SaveAnalysedImage_MenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodeToolStripMenuItem,
            this.decodeToolStripMenuItem,
            this.analyseEncodingToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(72, 26);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // encodeToolStripMenuItem
            // 
            this.encodeToolStripMenuItem.Name = "encodeToolStripMenuItem";
            this.encodeToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.encodeToolStripMenuItem.Text = "Encoding";
            this.encodeToolStripMenuItem.Click += new System.EventHandler(this.Encoding_MenuItem_Click);
            // 
            // decodeToolStripMenuItem
            // 
            this.decodeToolStripMenuItem.Name = "decodeToolStripMenuItem";
            this.decodeToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.decodeToolStripMenuItem.Text = "Decoding";
            this.decodeToolStripMenuItem.Click += new System.EventHandler(this.Decoding_MenuItem_Click);
            // 
            // analyseEncodingToolStripMenuItem
            // 
            this.analyseEncodingToolStripMenuItem.Name = "analyseEncodingToolStripMenuItem";
            this.analyseEncodingToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.analyseEncodingToolStripMenuItem.Text = "Analyse encoded JPEG";
            this.analyseEncodingToolStripMenuItem.Click += new System.EventHandler(this.AnalyseEncoding_MenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(57, 26);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.Clear_MenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.About_MenuItem_Click);
            // 
            // TextToDecode
            // 
            this.TextToDecode.Location = new System.Drawing.Point(855, 504);
            this.TextToDecode.Multiline = true;
            this.TextToDecode.Name = "TextToDecode";
            this.TextToDecode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextToDecode.Size = new System.Drawing.Size(458, 203);
            this.TextToDecode.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(6, 573);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "DCT positions that store bits";
            // 
            // EncodedImage_PictureBox
            // 
            this.EncodedImage_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EncodedImage_PictureBox.Location = new System.Drawing.Point(685, 63);
            this.EncodedImage_PictureBox.Name = "EncodedImage_PictureBox";
            this.EncodedImage_PictureBox.Size = new System.Drawing.Size(308, 408);
            this.EncodedImage_PictureBox.TabIndex = 28;
            this.EncodedImage_PictureBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(366, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(241, 25);
            this.label7.TabIndex = 29;
            this.label7.Text = "Image To Encode/Decode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(680, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 25);
            this.label8.TabIndex = 30;
            this.label8.Text = "Encoded Image";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(1000, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 25);
            this.label9.TabIndex = 31;
            this.label9.Text = "Analysed Image";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(12, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 25);
            this.label10.TabIndex = 32;
            this.label10.Text = "Logger";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(369, 481);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 20);
            this.label11.TabIndex = 33;
            this.label11.Text = "Text to encode";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(851, 481);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 20);
            this.label12.TabIndex = 34;
            this.label12.Text = "Decoded text";
            // 
            // ProgressBarText
            // 
            this.ProgressBarText.AutoSize = true;
            this.ProgressBarText.BackColor = System.Drawing.Color.Transparent;
            this.ProgressBarText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ProgressBarText.Location = new System.Drawing.Point(604, 727);
            this.ProgressBarText.Name = "ProgressBarText";
            this.ProgressBarText.Size = new System.Drawing.Size(0, 25);
            this.ProgressBarText.TabIndex = 35;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 770);
            this.Controls.Add(this.ProgressBarText);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.EncodedImage_PictureBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextToDecode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Resize_CheckBox);
            this.Controls.Add(this.LogPanel);
            this.Controls.Add(this.AnalysedImage_PictureBox);
            this.Controls.Add(this.Spectrum_ComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Offset_NumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.P2X);
            this.Controls.Add(this.P2Y);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.P1X);
            this.Controls.Add(this.P1Y);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.Key_NumericUpDown);
            this.Controls.Add(this.TextToEncode);
            this.Controls.Add(this.Image_PictureBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Koch&Zhao";
            ((System.ComponentModel.ISupportInitialize)(this.Image_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Key_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Offset_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnalysedImage_PictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EncodedImage_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Image_PictureBox;
        private System.Windows.Forms.TextBox TextToEncode;
        private System.Windows.Forms.NumericUpDown Key_NumericUpDown;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar P1X;
        private System.Windows.Forms.TrackBar P1Y;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar P2X;
        private System.Windows.Forms.TrackBar P2Y;
        private System.Windows.Forms.NumericUpDown Offset_NumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Spectrum_ComboBox;
        private System.Windows.Forms.PictureBox AnalysedImage_PictureBox;
        private System.Windows.Forms.TextBox LogPanel;
        private System.Windows.Forms.CheckBox Resize_CheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveEncodedImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDecodedTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAnalisedImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyseEncodingToolStripMenuItem;
        private System.Windows.Forms.TextBox TextToDecode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox EncodedImage_PictureBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Label ProgressBarText;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

