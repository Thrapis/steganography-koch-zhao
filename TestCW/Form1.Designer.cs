
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.button4 = new System.Windows.Forms.Button();
            this.logPanel = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(424, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 306);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(424, 346);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(773, 71);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 57);
            this.button2.TabIndex = 3;
            this.button2.Text = "Encode Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 172);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 57);
            this.button3.TabIndex = 4;
            this.button3.Text = "Decode Image";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(287, 326);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(94, 22);
            this.numericUpDown1.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(424, 437);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(773, 35);
            this.progressBar1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(73, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "P1 = [3, 4]";
            // 
            // P1X
            // 
            this.P1X.LargeChange = 1;
            this.P1X.Location = new System.Drawing.Point(67, 416);
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
            this.P1Y.Location = new System.Drawing.Point(11, 368);
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
            this.label2.Location = new System.Drawing.Point(264, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "P2 = [4, 3]";
            // 
            // P2X
            // 
            this.P2X.LargeChange = 1;
            this.P2X.Location = new System.Drawing.Point(258, 416);
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
            this.P2Y.Location = new System.Drawing.Point(202, 368);
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
            this.numericUpDown2.Location = new System.Drawing.Point(12, 325);
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
            this.label3.Location = new System.Drawing.Point(255, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Key (byte number)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(20, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Offset";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(132, 325);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.PropertiesChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(889, 21);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(308, 306);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(742, 135);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(137, 57);
            this.button4.TabIndex = 21;
            this.button4.Text = "Analise Encoding";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // logPanel
            // 
            this.logPanel.Location = new System.Drawing.Point(154, 21);
            this.logPanel.Multiline = true;
            this.logPanel.Name = "logPanel";
            this.logPanel.ReadOnly = true;
            this.logPanel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logPanel.Size = new System.Drawing.Size(256, 262);
            this.logPanel.TabIndex = 22;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(11, 261);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(129, 21);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Resize For Text";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(742, 232);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(128, 21);
            this.checkBox2.TabIndex = 24;
            this.checkBox2.Text = "Pixel Correction";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.PropertiesChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 484);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.logPanel);
            this.Controls.Add(this.button4);
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
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
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
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox logPanel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

