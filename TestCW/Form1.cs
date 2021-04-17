using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCW
{
    public partial class Form1 : Form, IProgressChanged
    {
        Bitmap Image;
        int ImageMaxBytes = 0;
        int Offset = 25;
        int SelectedSpectrum = 2;
        Point P1 = new Point(3, 4);
        Point P2 = new Point(4, 3);
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(@"E:\Study\ZIiNIS_Course_Work\TestCW\TestCW\Images\add_img.png");
            List<string> lst = new List<string>() { "Red", "Green", "Blue" };
            comboBox1.Items.AddRange(lst.ToArray());
            comboBox1.SelectedIndex = 2;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private Bitmap ResizeBitmapForData(Bitmap image, int byteToEncode)
        {
            Bitmap img;

            double coef = (double)byteToEncode / (double)ImageMaxBytes;
            int newWidth = (int)((double)Image.Width * coef);
            int newHeight = (int)((double)Image.Height * coef);

            img = Additions.ResizeBitmap((Bitmap)image.Clone(), newWidth, newHeight);

            pictureBox1.Image = img;
            ImageMaxBytes = (img.Width / 8) * (img.Height / 8) / 8;

            logPanel.Text = "";
            logPanel.Text += $"Can be encoded {ImageMaxBytes} bytes ({ImageMaxBytes * 8} bits)";
            return img;
        }

        private void PropertiesChanged(object sender, EventArgs e)
        {
            Offset = (int)numericUpDown2.Value;
            SelectedSpectrum = comboBox1.SelectedIndex;
            P1 = new Point(P1X.Value, P1Y.Value);
            P2 = new Point(P2X.Value, P2Y.Value);
            label1.Text = $"P1 = [{P1.Y}, {P1.X}]";
            label2.Text = $"P2 = [{P2.Y}, {P2.X}]";
            KochZhao.SetSettings(Offset, SelectedSpectrum, P1, P2);
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
            P1X.Enabled = true;
            P1Y.Enabled = true;
            P2X.Enabled = true;
            P2Y.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            comboBox1.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void OpenImage_MenuItem_Click(object sender, EventArgs e)
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

        private async void Encoding_MenuItem_Click(object sender, EventArgs e)
        {
            Bitmap img = Image;
            int byteToEncode = textBox1.Text.Length;

            if (ImageMaxBytes < byteToEncode)
            {
                if (checkBox1.Checked)
                {
                    img = ResizeBitmapForData((Bitmap)Image.Clone(), byteToEncode);
                }
                else
                    return;
            }

            LockUI();
            await Task.Run(() => {
                img = KochZhao.Encode(img, Encoding.GetEncoding(1251), textBox1.Text, SelectedSpectrum, this);
            });
            numericUpDown1.Value = byteToEncode;
            img.Save("encoded.bmp");
            img.Dispose();
            UnlockUI();
        }

        private async void Decoding_MenuItem_Click(object sender, EventArgs e)
        {
            LockUI();
            await Task.Run(() => {
                textBox1.Text = KochZhao.Decode(Image, Encoding.GetEncoding(1251), (int)numericUpDown1.Value, this);
            });
            UnlockUI();
        }

        private async void AnalyseEncoding_MenuItem_Click(object sender, EventArgs e)
        {
            Bitmap img = Image;
            int byteToEncode = textBox1.Text.Length;

            if (ImageMaxBytes < byteToEncode)
            {
                if (checkBox1.Checked)
                {
                    img = ResizeBitmapForData((Bitmap)Image.Clone(), byteToEncode);
                }
                else
                    return;
            }

            LockUI();
            string encodeText = textBox1.Text;
            string dencodeText = "";
            int badEncoded = 0;

            await Task.Run(() => {
                img = KochZhao.Encode(img, Encoding.GetEncoding(1251), textBox1.Text, SelectedSpectrum, this);
            });

            img.Save("encoded.bmp");
            numericUpDown1.Value = textBox1.Text.Length;

            await Task.Run(() => {
                dencodeText = KochZhao.Decode(img, Encoding.GetEncoding(1251), (int)numericUpDown1.Value, this);
            });

            await Task.Run(() => {
                (badEncoded, img) = KochZhao.DetectInvalideSqrOctopixels((Bitmap)img.Clone(), Encoding.GetEncoding(1251), encodeText, dencodeText, (int)numericUpDown1.Value, this);
            });

            pictureBox2.Image = img;
            logPanel.Text += $"\r\nBadEncoded: {badEncoded} bits";
            img.Save("analised.bmp");
            UnlockUI();
        }

        private void OpenText_MenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveEncodedImage_MenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveDecodedText_MenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveAnalysedImage_MenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
