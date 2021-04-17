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
	public partial class Form1 : Form, IProgressChanged
	{
		Bitmap OpenedImage;
		Bitmap EncodedImage;
		Bitmap AnalysedEncodedImage;
		int ImageMaxBytes = 0;
		int Offset = 25;
		int SelectedSpectrum = 2;
		Point P1 = new Point(3, 4);
		Point P2 = new Point(4, 3);
		bool UILocked = false;

		public Form1()
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

			img = Additions.ResizeBitmap(image, newWidth, newHeight);

			Image_PictureBox.Image = img;
			ImageMaxBytes = (img.Width / 8) * (img.Height / 8) / 8;

			LogPanel.Text = "";
			LogPanel.Text += $"Can be encoded {ImageMaxBytes} bytes ({ImageMaxBytes * 8} bits)";
			return img;
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
				LogPanel.Text += "\r\n";
			LogPanel.Text += message + "\r\n";
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
					img = ResizeBitmapForData(OpenedImage, byteToEncode);
				}
				else
					return;
			}
			LockUI();
			ProgressBarText.Text = "Encoding";
			await Task.Run(() => {
				img = KochZhao.Encode((Bitmap)img.Clone(), Encoding.GetEncoding(1251), TextToEncode.Text, SelectedSpectrum, this);
			});
			ProgressBarText.Text = "";
			EncodedImage = (Bitmap)img.Clone();
			EncodedImage_PictureBox.Image = EncodedImage;
			Key_NumericUpDown.Value = byteToEncode;
			Log($"{DateTime.Now} - Encoded: {TextToEncode.Text.Length} bytes");
			img.Dispose();
			UnlockUI();
		}

		private async void Decoding_MenuItem_Click(object sender, EventArgs e)
		{
			LockUI();
			ProgressBarText.Text = "Decoding";
			await Task.Run(() => {
				TextToDecode.Text = KochZhao.Decode(OpenedImage, Encoding.GetEncoding(1251), (int)Key_NumericUpDown.Value, this);
			});
			ProgressBarText.Text = "";
			Log($"{DateTime.Now} - Decoded: {TextToDecode.Text.Length} bytes");
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
					img = ResizeBitmapForData(OpenedImage, byteToEncode);
				}
				else
					return;
			}
			LockUI();
			string encodeText = TextToEncode.Text;
			string decodeText = "";
			int badEncoded = 0;
			ProgressBarText.Text = "Encoding";
			await Task.Run(() => {
				img = KochZhao.Encode((Bitmap)img.Clone(), Encoding.GetEncoding(1251), TextToEncode.Text, SelectedSpectrum, this);
			});
			EncodedImage = (Bitmap)img.Clone();
			EncodedImage_PictureBox.Image = EncodedImage;
			Key_NumericUpDown.Value = TextToEncode.Text.Length;
			Log($"{DateTime.Now} - Encoded: {TextToEncode.Text.Length} bytes");
			ProgressBarText.Text = "Decoding";
			await Task.Run(() => {
				decodeText = KochZhao.Decode(img, Encoding.GetEncoding(1251), (int)Key_NumericUpDown.Value, this);
			});
			TextToDecode.Text = decodeText;
			Log($"{DateTime.Now} - Decoded: {TextToDecode.Text.Length} bytes");
			ProgressBarText.Text = "Analysing";
			await Task.Run(() => {
				(badEncoded, img) = KochZhao.DetectInvalideSqrOctopixels((Bitmap)img.Clone(), Encoding.GetEncoding(1251), encodeText, decodeText, (int)Key_NumericUpDown.Value, this);
			});
			ProgressBarText.Text = "";
			AnalysedEncodedImage = (Bitmap)img.Clone();
			AnalysedImage_PictureBox.Image = AnalysedEncodedImage;
			Log($"{DateTime.Now} - BadEncoded: {badEncoded} bits");
			UnlockUI();
		}

		private void OpenText_MenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Text file | *.txt";
			string text = "";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				string fileName = ofd.FileName;

				using (StreamReader sr = new StreamReader(fileName))
				{
					text = sr.ReadToEnd();
				}
				Log($"{DateTime.Now} - Opened text file {fileName}");
			}
			TextToEncode.Text = text;
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
				Log($"{DateTime.Now} - Saved encoded image {fileName}");
			}
		}

		private void SaveDecodedText_MenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Save Decoded Text";
			sfd.AddExtension = true;
			sfd.DefaultExt = "*.txt";
			sfd.Filter = "Text file | *.txt";

			string text = TextToDecode.Text;

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string fileName = sfd.FileName;

				using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8))
				{
					sw.Write(text);
				}
				Log($"{DateTime.Now} - Saved decoded text {fileName}");
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
				Log($"{DateTime.Now} - Saved analysed image {fileName}");
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
    }
}
