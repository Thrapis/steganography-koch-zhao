
namespace TestCW
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.P1X = new System.Windows.Forms.TrackBar();
            this.P1Y = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.P2X = new System.Windows.Forms.TrackBar();
            this.P2Y = new System.Windows.Forms.TrackBar();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.logPanel = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveEncodedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDecodedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAnalisedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseEncodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(449, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 306);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(449, 374);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(361, 203);
            this.textBox1.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(286, 482);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(135, 22);
            this.numericUpDown1.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(540, 593);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(773, 35);
            this.progressBar1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(72, 538);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "P1 = [3, 4]";
            // 
            // P1X
            // 
            this.P1X.LargeChange = 1;
            this.P1X.Location = new System.Drawing.Point(66, 572);
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
            this.P1Y.Location = new System.Drawing.Point(10, 524);
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
            this.label2.Location = new System.Drawing.Point(263, 538);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "P2 = [4, 3]";
            // 
            // P2X
            // 
            this.P2X.LargeChange = 1;
            this.P2X.Location = new System.Drawing.Point(257, 572);
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
            this.P2Y.Location = new System.Drawing.Point(201, 524);
            this.P2Y.Maximum = 7;
            this.P2Y.Name = "P2Y";
            this.P2Y.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.P2Y.Size = new System.Drawing.Size(56, 104);
            this.P2Y.TabIndex = 13;
            this.P2Y.Value = 4;
            this.P2Y.Scroll += new System.EventHandler(this.PropertiesChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(11, 481);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(94, 22);
            this.numericUpDown2.TabIndex = 16;
            this.numericUpDown2.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.PropertiesChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(282, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Key (byte number)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(19, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Offset";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(131, 481);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.PropertiesChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(964, 32);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(308, 306);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // logPanel
            // 
            this.logPanel.Location = new System.Drawing.Point(12, 79);
            this.logPanel.Multiline = true;
            this.logPanel.Name = "logPanel";
            this.logPanel.ReadOnly = true;
            this.logPanel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logPanel.Size = new System.Drawing.Size(274, 306);
            this.logPanel.TabIndex = 22;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(190, 407);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(159, 21);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Resize For Message";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(141, 458);
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
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1325, 28);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openTextToolStripMenuItem,
            this.saveEncodedImageToolStripMenuItem,
            this.saveDecodedTextToolStripMenuItem,
            this.saveAnalisedImageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.openToolStripMenuItem.Text = "Open image";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenImage_MenuItem_Click);
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
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // encodeToolStripMenuItem
            // 
            this.encodeToolStripMenuItem.Name = "encodeToolStripMenuItem";
            this.encodeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.encodeToolStripMenuItem.Text = "Encoding";
            this.encodeToolStripMenuItem.Click += new System.EventHandler(this.Encoding_MenuItem_Click);
            // 
            // decodeToolStripMenuItem
            // 
            this.decodeToolStripMenuItem.Name = "decodeToolStripMenuItem";
            this.decodeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.decodeToolStripMenuItem.Text = "Decoding";
            this.decodeToolStripMenuItem.Click += new System.EventHandler(this.Decoding_MenuItem_Click);
            // 
            // analyseEncodingToolStripMenuItem
            // 
            this.analyseEncodingToolStripMenuItem.Name = "analyseEncodingToolStripMenuItem";
            this.analyseEncodingToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.analyseEncodingToolStripMenuItem.Text = "Analyse encoding";
            this.analyseEncodingToolStripMenuItem.Click += new System.EventHandler(this.AnalyseEncoding_MenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 640);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.logPanel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.P2X);
            this.Controls.Add(this.P2Y);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.P1X);
            this.Controls.Add(this.P1Y);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar P1X;
        private System.Windows.Forms.TrackBar P1Y;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar P2X;
        private System.Windows.Forms.TrackBar P2Y;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox logPanel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveEncodedImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDecodedTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAnalisedImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyseEncodingToolStripMenuItem;
    }
}

