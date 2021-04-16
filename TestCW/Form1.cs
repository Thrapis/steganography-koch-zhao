using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Collections;
using System.Drawing.Imaging;
using System.Threading;

namespace TestCW
{
    public partial class Form1 : Form, IProgressChanged
    {
        
        Bitmap Image;
        int ImageMaxBytes = 0;
        int Offset = 150;
        int SelectedSpecter = 2;
        Point P1 = new Point(3, 4);
        Point P2 = new Point(4, 3);
        bool PixelCorrection = false;

        public Form1()
        {
            InitializeComponent();
            List<string> lst = new List<string>() { "Red", "Green", "Blue" };
            comboBox1.Items.AddRange(lst.ToArray());
            comboBox1.SelectedIndex = 2;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            double[,] cost, e;
            (cost, e) = KeysDCT.GenCostAndE();
            for (int i = 0; i < cost.GetLength(1); i++)
            {
                for (int j = 0; j < cost.GetLength(0); j++)
                {
                    Console.Write(cost[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image | *.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (Image != null)
                    Image.Dispose();
                Image = new Bitmap(ofd.FileName);
                pictureBox1.Image = Image;

                ImageMaxBytes = (Image.Width / 8) * (Image.Height / 8) / 8;

                logPanel.Text = "";
                logPanel.Text += $"Can be encoded {ImageMaxBytes} bytes ({ImageMaxBytes * 8} bits)";
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Bitmap img = Image;
            int byteToEncode = textBox1.Text.Length;
            if (ImageMaxBytes > byteToEncode)
            {
                if (checkBox1.Checked)
                {
                    double coef = (double)byteToEncode / (double)ImageMaxBytes;
                    int newWidth = (int)((double)Image.Width * coef);
                    int newHeight = (int)((double)Image.Height * coef);

                    img = Additions.ResizeBitmap(Image, newWidth, newHeight);

                    Image = img;
                    pictureBox1.Image = img;

                    ImageMaxBytes = (Image.Width / 8) * (Image.Height / 8) / 8;

                    logPanel.Text = "";
                    logPanel.Text += $"Can be encoded {ImageMaxBytes} bytes ({ImageMaxBytes * 8} bits)";
                }
                else
                    return;
            }

            LockUI();
            await Task.Run(() => {
                img = KochZhao.Encode(img, Encoding.GetEncoding(1251), textBox1.Text, SelectedSpecter, this);
            });
            numericUpDown1.Value = byteToEncode;
            img.Save("encoded.bmp");
            img.Dispose();
            UnlockUI();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            LockUI();
            await Task.Run(() => {
                textBox1.Text = KochZhao.Decode(Image, Encoding.GetEncoding(1251), (int)numericUpDown1.Value, this);
            });
            UnlockUI();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            Bitmap img = Image;
            int byteToEncode = textBox1.Text.Length;

            if (ImageMaxBytes < byteToEncode)
            {
                if (checkBox1.Checked)
                {
                    double coef = (double)byteToEncode / (double)ImageMaxBytes;
                    int newWidth = (int)((double)Image.Width * coef);
                    int newHeight = (int)((double)Image.Height * coef);

                    img = Image.ResizeBitmap(newWidth, newHeight);

                    Image = (Bitmap)img.Clone();
                    pictureBox1.Image = img;

                    ImageMaxBytes = (Image.Width / 8) * (Image.Height / 8) / 8;

                    logPanel.Text = "";
                    logPanel.Text += $"Can be encoded {ImageMaxBytes} bytes ({ImageMaxBytes * 8} bits)";
                }
                else
                    return;
            }

            LockUI();
            string encodeText = textBox1.Text;
            string dencodeText = "";
            int badEncoded = 0;

            await Task.Run(() => {
                img = KochZhao.Encode(Image, Encoding.GetEncoding(1251), textBox1.Text, SelectedSpecter, this, PixelCorrection);
            });

            img.Save("encoded.bmp");
            numericUpDown1.Value = textBox1.Text.Length;

            await Task.Run(() => {
                dencodeText = KochZhao.Decode(img, Encoding.GetEncoding(1251), (int)numericUpDown1.Value, this);
            });

            await Task.Run(() => {
                (badEncoded, img) = KochZhao.DetectInvalideSqrOctopixels(img, Encoding.GetEncoding(1251), encodeText, dencodeText, (int)numericUpDown1.Value, this);
            });

            pictureBox2.Image = img;
            logPanel.Text += $"\r\nBadEncoded: {badEncoded} bits";
            img.Save("analised.bmp");
            UnlockUI();
        }

        private void PropertiesChanged(object sender, EventArgs e)
        {
            Offset = (int)numericUpDown2.Value;
            SelectedSpecter = comboBox1.SelectedIndex;
            P1 = new Point(P1X.Value, P1Y.Value);
            P2 = new Point(P2X.Value, P2Y.Value);
            label1.Text = $"P1 = [{P1.Y}, {P1.X}]";
            label2.Text = $"P2 = [{P2.Y}, {P2.X}]";
            KochZhao.SetSettings(Offset, SelectedSpecter, P1, P2);
            PixelCorrection = checkBox2.Checked;
        }

        public void ChangeProgress(int val)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { progressBar1.Value = val; });
            else
                progressBar1.Value = val;
        }

        private void LockUI()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            P1X.Enabled = false;
            P1Y.Enabled = false;
            P2X.Enabled = false;
            P2Y.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            comboBox1.Enabled = false;
            checkBox1.Enabled = false;
        }

        private void UnlockUI()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            P1X.Enabled = true;
            P1Y.Enabled = true;
            P2X.Enabled = true;
            P2Y.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            comboBox1.Enabled = true;
            checkBox1.Enabled = true;
        }

    }
}
