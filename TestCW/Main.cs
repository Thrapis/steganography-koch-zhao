using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCW
{
	public partial class Main : Form, IProgressChanged
	{
		private Bitmap OpenedImage;
		private Bitmap EncodedImage;
		private Bitmap AnalysedEncodedImage;
		private int ImageMaxBytes = 0;
		private int Offset = 25;
		private int SelectedSpectrum = 2;
		private Point P1 = new Point(3, 4);
		private Point P2 = new Point(4, 3);
		private bool UILocked = false;

		public Main()
		{
			InitializeComponent();
			List<string> lst = new List<string>() { "Red", "Green", "Blue" };
			Spectrum_ComboBox.Items.AddRange(lst.ToArray());
			Spectrum_ComboBox.SelectedIndex = 2;

			Image_PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			Image_PictureBox.BackgroundImageLayout = ImageLayout.Stretch;
			EncodedImage_PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			AnalysedImage_PictureBox.SizeMode = PictureBoxSizeMode.Zoom;

			UpdateButtonsState();
		}

		private Bitmap ResizeBitmapForData(Bitmap image, int byteToEncode)
		{
			Bitmap img;

			double coef = (double)byteToEncode / (double)ImageMaxBytes;
			int newWidth = (int)((double)OpenedImage.Width * coef);
			int newHeight = (int)((double)OpenedImage.Height * coef);

			DateTime time1 = DateTime.Now;
			img = Additions.ResizeBitmap(image, newWidth, newHeight);
			DateTime time2 = DateTime.Now;

			Image_PictureBox.Image = img;
			OpenedImage = img;
			ImageMaxBytes = (img.Width / 8) * (img.Height / 8) / 8;

			Log($"Image resized. Can be encoded {ImageMaxBytes} bytes ({ImageMaxBytes * 8} bits). Resize image time {time2 - time1}");
			return (Bitmap)img.Clone();
		}

		private void PropertiesChanged(object sender, EventArgs e)
		{
			Offset = (int)Offset_NumericUpDown.Value;
			SelectedSpectrum = Spectrum_ComboBox.SelectedIndex;
			P1 = new Point(P1X.Value, P1Y.Value);
			P2 = new Point(P2X.Value, P2Y.Value);
			label1.Text = $"P1 = [{P1.Y}, {P1.X}]";
			label2.Text = $"P2 = [{P2.Y}, {P2.X}]";
			KochZhao.SetSettings(Offset, SelectedSpectrum, P1, P2);
			UpdateButtonsState();
		}

		public void ChangeProgress(int val)
		{
			if (InvokeRequired)
				Invoke((MethodInvoker)delegate { ProgressBar.Value = val; });
			else
				ProgressBar.Value = val;
		}

		private void LockUI()
		{
			if (!UILocked)
			{
				P1X.Enabled = false;
				P1Y.Enabled = false;
				P2X.Enabled = false;
				P2Y.Enabled = false;
				Key_NumericUpDown.Enabled = false;
				Offset_NumericUpDown.Enabled = false;
				Spectrum_ComboBox.Enabled = false;
				Resize_CheckBox.Enabled = false;
				openImageToolStripMenuItem.Enabled = false;
				openTextToolStripMenuItem.Enabled = false;
				clearToolStripMenuItem.Enabled = false;
				Image_PictureBox.Enabled = false;
				TextToEncode.Enabled = false;
				TextToDecode.Enabled = false;

				UILocked = true;
			}
			UpdateButtonsState();
		}

		private void UnlockUI()
		{
			if (UILocked)
			{
				P1X.Enabled = true;
				P1Y.Enabled = true;
				P2X.Enabled = true;
				P2Y.Enabled = true;
				Key_NumericUpDown.Enabled = true;
				Offset_NumericUpDown.Enabled = true;
				Spectrum_ComboBox.Enabled = true;
				Resize_CheckBox.Enabled = true;
				openImageToolStripMenuItem.Enabled = true;
				openTextToolStripMenuItem.Enabled = true;
				clearToolStripMenuItem.Enabled = true;
				Image_PictureBox.Enabled = true;
				TextToEncode.Enabled = true;
				TextToDecode.Enabled = true;

				UILocked = false;
			}
			UpdateButtonsState();
		}

		private void UpdateButtonsState()
		{
			if (UILocked)
			{
				saveEncodedImageToolStripMenuItem.Enabled = false;
				saveDecodedTextToolStripMenuItem.Enabled = false;
				saveAnalisedImageToolStripMenuItem.Enabled = false;
				encodeToolStripMenuItem.Enabled = false;
				decodeToolStripMenuItem.Enabled = false;
				analyseEncodingToolStripMenuItem.Enabled = false;
			}
			else
			{
				saveEncodedImageToolStripMenuItem.Enabled = EncodedImage != null;
				saveDecodedTextToolStripMenuItem.Enabled = TextToDecode.Text != "";
				saveAnalisedImageToolStripMenuItem.Enabled = AnalysedEncodedImage != null;
				encodeToolStripMenuItem.Enabled = OpenedImage != null && TextToEncode.Text != "";
				decodeToolStripMenuItem.Enabled = OpenedImage != null;
				analyseEncodingToolStripMenuItem.Enabled = OpenedImage != null && TextToEncode.Text != "";
			}
		}

		private void Log(string message)
        {
			if (LogPanel.Text.Length != 0)
				LogPanel.AppendText("\r\n");
			LogPanel.AppendText($"{DateTime.Now} - " + message + "\r\n");
		}

		private void Image_PictureBox_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Open Image";
			ofd.Filter = "Image Files(*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg|32-bit image (*.bmp)|*.bmp|PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				if (OpenedImage != null)
					OpenedImage.Dispose();

				using (Stream bmpStream = File.Open(ofd.FileName, FileMode.Open))
				{
					Image image = Image.FromStream(bmpStream);
					OpenedImage = new Bitmap(image);
				}

				Image_PictureBox.Image = OpenedImage;

				ImageMaxBytes = (OpenedImage.Width / 8) * (OpenedImage.Height / 8) / 8;

				Log($"Opened image {ofd.FileName}\r\nCan be encoded {ImageMaxBytes} bytes ({ImageMaxBytes * 8} bits)");
			}
			UpdateButtonsState();
		}

		private void OpenImage_MenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Open Image";
			ofd.Filter = "Image file (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg|32-bit image (*.bmp)|*.bmp|PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				if (OpenedImage != null)
					OpenedImage.Dispose();

				using (Stream bmpStream = File.Open(ofd.FileName, FileMode.Open))
				{
					Image image = Image.FromStream(bmpStream);
					OpenedImage = new Bitmap(image);
				}

				Image_PictureBox.Image = OpenedImage;

				ImageMaxBytes = (OpenedImage.Width / 8) * (OpenedImage.Height / 8) / 8;

				Log($"Opened image {ofd.FileName}\r\nCan be encoded {ImageMaxBytes} bytes ({ImageMaxBytes * 8} bits)");
			}
			UpdateButtonsState();
		}

		private async void Encoding_MenuItem_Click(object sender, EventArgs e)
		{
			Bitmap img = OpenedImage;
			int byteToEncode = TextToEncode.Text.Length;
			if (ImageMaxBytes < byteToEncode)
			{
				if (Resize_CheckBox.Checked)
				{
					img = ResizeBitmapForData((Bitmap)OpenedImage.Clone(), byteToEncode);
				}
				else
				{
					MessageBox.Show("Image too small to encode this text!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}
			LockUI();
			ProgressBarText.Text = "Encoding";
			Bitmap buf = new Bitmap(img);
			img.Dispose();
			DateTime time1 = DateTime.Now;
			await Task.Run(() => {
				img = KochZhao.Encode(buf, Encoding.GetEncoding(1251), TextToEncode.Text, SelectedSpectrum, this);
			});
			DateTime time2 = DateTime.Now;
			ProgressBarText.Text = "";
			EncodedImage = (Bitmap)img.Clone();
			EncodedImage_PictureBox.Image = EncodedImage;
			Key_NumericUpDown.Value = byteToEncode;
			Log($"Encoded: {TextToEncode.Text.Length} bytes. Encoding time {time2 - time1}");
			img.Dispose();
			UnlockUI();
		}

		private async void Decoding_MenuItem_Click(object sender, EventArgs e)
		{
			LockUI();
			ProgressBarText.Text = "Decoding";
			DateTime time1 = DateTime.Now;
			await Task.Run(() => {
				TextToDecode.Text = KochZhao.Decode(OpenedImage, Encoding.GetEncoding(1251), (int)Key_NumericUpDown.Value, this);
			});
			DateTime time2 = DateTime.Now;
			ProgressBarText.Text = "";
			Log($"Decoded: {TextToDecode.Text.Length} bytes. Decoding time {time2 - time1}");
			UnlockUI();
		}

		private async void AnalyseEncoding_MenuItem_Click(object sender, EventArgs e)
		{
			Bitmap img = OpenedImage;
			int byteToEncode = TextToEncode.Text.Length;
			if (ImageMaxBytes < byteToEncode)
			{
				if (Resize_CheckBox.Checked)
				{
					img = ResizeBitmapForData((Bitmap)OpenedImage.Clone(), byteToEncode);
				}
				else
				{
					MessageBox.Show("Image too small to encode this text!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}
			LockUI();
			string encodeText = TextToEncode.Text;
			string decodeText = "";
			int badEncoded = 0;
			ProgressBarText.Text = "Encoding";
			Bitmap buf = new Bitmap(img);
			img.Dispose();
			DateTime time1 = DateTime.Now;
			await Task.Run(() => {
				img = KochZhao.Encode(buf, Encoding.GetEncoding(1251), TextToEncode.Text, SelectedSpectrum, this);
			});
			Log($"Encoded: {TextToEncode.Text.Length} bytes");
			EncodedImage = (Bitmap)img.Clone();
			img.Save("temp.jpg", ImageFormat.Jpeg);
			Bitmap encodedJpegImg = null;
			using (Stream bmpStream = File.Open("temp.jpg", FileMode.Open))
			{
				encodedJpegImg = (Bitmap)Image.FromStream(bmpStream);
			}
			File.Delete("temp.jpg");
			EncodedImage_PictureBox.Image = EncodedImage;
			Key_NumericUpDown.Value = TextToEncode.Text.Length;
			ProgressBarText.Text = "Decoding";
			await Task.Run(() => {
				decodeText = KochZhao.Decode((Bitmap)encodedJpegImg.Clone(), Encoding.GetEncoding(1251), (int)Key_NumericUpDown.Value, this);
			});
			TextToDecode.Text = decodeText;
			Log($"Decoded: {TextToDecode.Text.Length} bytes");
			ProgressBarText.Text = "Analysing";
			Bitmap analysedImg = null;
			await Task.Run(() => {
				(badEncoded, analysedImg) = KochZhao.DetectInvalideSqrOctopixels((Bitmap)img.Clone(), Encoding.GetEncoding(1251), encodeText, decodeText, (int)Key_NumericUpDown.Value, this);
			});
			DateTime time2 = DateTime.Now;
			ProgressBarText.Text = "";
			AnalysedEncodedImage = (Bitmap)analysedImg.Clone();
			AnalysedImage_PictureBox.Image = AnalysedEncodedImage;
			Log($"BadEncoded: {badEncoded}/{(int)Key_NumericUpDown.Value * 8} bits. Analyse encoding time {time2 - time1}");
			UnlockUI();
		}

		private void OpenText_MenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Open text";
			ofd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				string fileName = ofd.FileName;
				using (StreamReader sr = new StreamReader(fileName))
				{
					TextToEncode.Text = sr.ReadToEnd();
				}
				Log($"Opened text file {fileName}. Text weight {TextToEncode.Text.Length} bytes");
			}
		}

		private void SaveEncodedImage_MenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Save Encoded Image";
			sfd.AddExtension = true;
			sfd.DefaultExt = "*.bmp";
			sfd.Filter = "32-bit image (*.bmp)| *.bmp|PNG (*.png)| *.png|JPEG (*.jpg)| *.jpg";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				int filterIndex = sfd.FilterIndex;
				string fileName = sfd.FileName;

				switch (filterIndex)
				{
					case 1: EncodedImage.Save(fileName, ImageFormat.Bmp); break;
					case 2: EncodedImage.Save(fileName, ImageFormat.Png); break;
					case 3: EncodedImage.Save(fileName, ImageFormat.Jpeg); break;
				}
				Log($"Saved encoded image {fileName}");
			}
		}

		private void SaveDecodedText_MenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Save Decoded Text";
			sfd.AddExtension = true;
			sfd.DefaultExt = "*.txt";
			sfd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";

			string text = TextToDecode.Text;

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string fileName = sfd.FileName;

				using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.ASCII))
				{
					sw.Write(text);
				}
				Log($"Saved decoded text {fileName}");
			}
		}

		private void SaveAnalysedImage_MenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Save Analysed Image";
			sfd.AddExtension = true;
			sfd.DefaultExt = "*.bmp";
			sfd.Filter = "32-bit image (*.bmp)| *.bmp|PNG (*.png)| *.png|JPEG (*.jpg)| *.jpg";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				int filterIndex = sfd.FilterIndex;
				string fileName = sfd.FileName;

				switch (filterIndex)
				{
					case 1: AnalysedEncodedImage.Save(fileName, ImageFormat.Bmp); break;
					case 2: AnalysedEncodedImage.Save(fileName, ImageFormat.Png); break;
					case 3: AnalysedEncodedImage.Save(fileName, ImageFormat.Jpeg); break;
				}
				Log($"Saved analysed image {fileName}");
			}
		}

        private void Clear_MenuItem_Click(object sender, EventArgs e)
        {
			OpenedImage = null;
			EncodedImage = null;
			AnalysedEncodedImage = null;
			Image_PictureBox.Image = null;
			EncodedImage_PictureBox.Image = null;
			AnalysedImage_PictureBox.Image = null;
			TextToEncode.Text = "";
			TextToDecode.Text = "";
			Key_NumericUpDown.Value = 0;
			Offset_NumericUpDown.Value = 25;
			P1Y.Value = 3;
			P1X.Value = 4;
			P2Y.Value = 4;
			P2X.Value = 3;
			LogPanel.Text = "";
			Resize_CheckBox.Checked = true;
			Spectrum_ComboBox.SelectedIndex = 2;
			ChangeProgress(0);
			PropertiesChanged(null, null);
        }

        private void About_MenuItem_Click(object sender, EventArgs e)
        {
			AboutWindow window = new AboutWindow();
			window.ShowDialog();
        }
    }
}
