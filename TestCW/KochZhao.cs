using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCW
{
	public static class KochZhao
	{
		private const int RGBSum = 255 + 255 + 255;
		private static int Offset = 150;
		private static int SelectedSpecter = 2;
		private static Point P1 = new Point(3, 4);
		private static Point P2 = new Point(4, 3);

		public static void SetSettings(int offset, int specter, Point p1, Point p2)
		{
			Offset = offset;
			SelectedSpecter = specter;
			if (p1.X >= 0 && p1.X <= 7 && p1.Y >= 0 && p1.Y <= 7)
				P1 = p1;
			if (p2.X >= 0 && p2.X <= 7 && p2.Y >= 0 && p2.Y <= 7)
				P2 = p2;
		}

		public static (int, int, Point, Point) GetSettings() /// offest, specter, p1, p2
		{
			return (Offset, SelectedSpecter, P1, P2);
		}

		private static BitArray ToBinaryString(Encoding encoding, string text)
		{
			string stream = string.Join("", encoding.GetBytes(text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
			BitArray ba = new BitArray(stream.Length);
			for (int i = 0; i < stream.Length; i++)
			{
				if (stream[i] == '0')
					ba[i] = false;
				else
					ba[i] = true;
			}
			return ba;
		}

		private static string ToStringBinary(Encoding encoding, BitArray bitArray)
		{
			return encoding.GetString(bitArray.BitArrayToByteArray());
		}

		public static double[,] GetDCT(byte[,] temp_bm)
		{
			double[,] dct = new double[8, 8];

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					double temp = 0;

					for (int x = 0; x < 8; x++)
					{
						for (int y = 0; y < 8; y++)
						{
							temp += KeysDCT.cos_t[i, x] * KeysDCT.cos_t[j, y] * (double)temp_bm[x, y];
						}
					}
					dct[i, j] = KeysDCT.e[i, j] * temp;
				}
			}
			return dct;
		}

		public static byte[,] GetIDCT(double[,] dct)
		{
			byte[,] arr = new byte[8, 8];

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					double temp = 0;

					for (int x = 0; x < 8; x++)
					{
						for (int y = 0; y < 8; y++)
						{
							temp += dct[x, y] * KeysDCT.cos_t[x, i] * KeysDCT.cos_t[y, j] * KeysDCT.e[x, y];
							byte spect = temp > 255 ? (byte)255 : (byte)Math.Round(temp);
							arr[i, j] = spect;
						}
					}
				}
			}
			return arr;
		}

		public static Bitmap Encode(Bitmap toCloneImg, Encoding encoding, string text, int selectedSpecter, IProgressChanged form = null, bool pixelCorrection = false)
		{
			if (form != null)
				form.ChangeProgress(5);

			BitArray textBits = ToBinaryString(encoding, text);
			Bitmap img = (Bitmap)toCloneImg.Clone();
			int l = 0;
			double k = 0;

			if (form != null)
				form.ChangeProgress(20 / (textBits.Count + 20) * 100);

			byte[,] temp_bm = new byte[8, 8];
			for (int i = 0; i + 7 < img.Height; i += 8)
			{
				for (int j = 0; j + 7 < img.Width; j += 8)
				{
					if (l >= textBits.Count)
						break;

					for (int y = 0; y < 8; y++)
					{
						for (int x = 0; x < 8; x++)
						{
							Color cl = img.GetPixel(x + j, y + i);
							if (selectedSpecter == 0)
								temp_bm[x, y] = cl.R;
							else if (selectedSpecter == 1)
								temp_bm[x, y] = cl.G;
							else if (selectedSpecter == 2)
								temp_bm[x, y] = cl.B;
						}
					}

					double[,] dct = GetDCT(temp_bm);

					if (l == 5294)
					{
						Console.WriteLine();
					}

					double P1b = Math.Abs(dct[P1.Y, P1.X]);
					double P2b = Math.Abs(dct[P2.Y, P2.X]);

					bool good_idct = false;

					while (!good_idct)
                    {
						bool encr_bit = false;

						while (!encr_bit)
						{
							k = Math.Abs(dct[P1.Y, P1.X]) - Math.Abs(dct[P2.Y, P2.X]);
							if (textBits[l]) // K1 - K2 > Offset    ->   1
							{
								if (k <= Offset)
								{
									//dct[P1.Y, P1.X] = dct[P1.Y, P1.X] >= 0 ? Math.Abs(dct[P2.Y, P2.X]) + Offset :
									//	-1 * (Math.Abs(dct[P2.Y, P2.X]) + Offset);
									dct[P1.Y, P1.X] += dct[P1.Y, P1.X] >= 0 ? 1 : -1;
									dct[P2.Y, P2.X] += dct[P2.Y, P2.X] >= 0 ? -1 : 1;
								}
								else
								{
									encr_bit = true;
								}
							}
							else            // K1 - K2 < -Offset     ->   0
							{
								if (k >= -Offset)
								{
									//dct[P2.Y, P2.X] = dct[P2.Y, P2.X] >= 0 ? Math.Abs(dct[P1.Y, P1.X]) + Offset :
									//	-1 * (Math.Abs(dct[P1.Y, P1.X]) + Offset);
									dct[P1.Y, P1.X] += dct[P1.Y, P1.X] >= 0 ? -1 : 1;
									dct[P2.Y, P2.X] += dct[P2.Y, P2.X] >= 0 ? 1 : -1;
								}
								else
								{
									encr_bit = true;
								}
							}
						}

						double[,] buf_dct = GetDCT(GetIDCT(dct));
						k = Math.Abs(buf_dct[P1.Y, P1.X]) - Math.Abs(buf_dct[P2.Y, P2.X]);
						if (textBits[l]) // K1 - K2 > Offset    ->   1
						{
							if (k >= 0)
								good_idct = true;
							else
								dct = buf_dct;
						}
						else            // K1 - K2 < -Offset     ->   0
						{
							if (k < 0)
								good_idct = true;
							else
								dct = buf_dct;
						}
					}

					

					P1b = Math.Abs(dct[P1.Y, P1.X]);
					P2b = Math.Abs(dct[P2.Y, P2.X]);
					k = Math.Abs(dct[P1.Y, P1.X]) - Math.Abs(dct[P2.Y, P2.X]);

					temp_bm = GetIDCT(dct);

					if (l == 5294)
					{
						Console.WriteLine("Modif dct");
						dct.EnterToConsole();
						Console.WriteLine("Modif idct");
						temp_bm.EnterToConsole();
					}


					for (int y = 0; y < 8; y++)
					{
						for (int x = 0; x < 8; x++)
						{
							Color old = img.GetPixel(x + j, y + i);
							Color cl = new Color();
							if (selectedSpecter == 0)
								cl = Color.FromArgb(temp_bm[x, y], old.G, old.B);
							else if (selectedSpecter == 1)
								cl = Color.FromArgb(old.R, temp_bm[x, y], old.B);
							else if (selectedSpecter == 2)
								cl = Color.FromArgb(old.R, old.G, temp_bm[x, y]);
							img.SetPixel(x + j, y + i, cl);
						}
					}

					l++;
					if (form != null)
						form.ChangeProgress((int)(((double)l + 20) / (double)(textBits.Count + 20) * 100));
				}

				if (l >= textBits.Count)
					break;
			}

			if (form != null)
				form.ChangeProgress(100);
			return img;
		}

		public static string Decode(Bitmap img, Encoding encoding, int key, IProgressChanged form = null)
		{
			if (form != null)
				form.ChangeProgress(5);

			List<bool> textBits = new List<bool>();
			int l = 0;
			int bitCount = key * 8;

			if (form != null)
				form.ChangeProgress(20 / (bitCount + 20) * 100);

			byte[,] temp_bm = new byte[8, 8];
			for (int i = 0; i + 7 < img.Height; i += 8)
			{
				for (int j = 0; j + 7 < img.Width; j += 8)
				{
					if (l >= bitCount)
						break;

					for (int y = 0; y < 8; y++)
					{
						for (int x = 0; x < 8; x++)
						{
							Color cl = img.GetPixel(x + j, y + i);
							if (SelectedSpecter == 0)
								temp_bm[x, y] = cl.R;
							else if (SelectedSpecter == 1)
								temp_bm[x, y] = cl.G;
							else if (SelectedSpecter == 2)
								temp_bm[x, y] = cl.B;
						}
					}

					double[,] dct = GetDCT(temp_bm);

					if (l == 5294)
					{
						Console.WriteLine("Modif idct");
						temp_bm.EnterToConsole();
						Console.WriteLine("Modif dct");
						dct.EnterToConsole();
						Console.WriteLine("BackModif idct");
						GetIDCT(dct).EnterToConsole();
					}

					double P1b = Math.Abs(dct[P1.Y, P1.X]);
					double P2b = Math.Abs(dct[P2.Y, P2.X]);
					double k = P1b - P2b;

					if (Math.Abs(dct[P1.Y, P1.X]) > Math.Abs(dct[P2.Y, P2.X]))
					{
						textBits.Add(true);
						l++;
					}
					else
					{
						textBits.Add(false);
						l++;
					}
				}

				if (l >= bitCount)
					break;

				if (form != null)
					form.ChangeProgress((int)(((double)l + 20) / (double)(bitCount + 20) * 100));
			}

			string text = ToStringBinary(encoding, new BitArray(textBits.ToArray()));

			if (form != null)
				form.ChangeProgress(100);
			return text;
		}

		public static (int, Bitmap) DetectInvalideSqrOctopixels(Bitmap img, Encoding encoding, string encodeText, string decodeText, int key, IProgressChanged form = null)
		{
			if (form != null)
				form.ChangeProgress(5);

			Color[,] colors = new Color[8, 8];
			int l = 0;
			int badEncoded = 0;
			int bitCount = key * 8;

			BitArray encodeTextBits = ToBinaryString(encoding, encodeText);
			BitArray decodeTextBits = ToBinaryString(encoding, decodeText);

			if (encodeTextBits.Count != decodeTextBits.Count)
				throw new Exception("Different messages length!");

			for (int i = 0; i + 7 < img.Height; i += 8)
			{
				for (int j = 0; j + 7 < img.Width; j += 8)
				{
					if (l >= bitCount)
						break;

					if (encodeTextBits[l] != decodeTextBits[l])
					{
						bool enc = encodeTextBits[l];
						bool dec = decodeTextBits[l];
						badEncoded++;

						for (int y = 0; y < 8; y++)
						{
							for (int x = 0; x < 8; x++)
							{
								colors[y, x] = img.GetPixel(x + j, y + i);
							}
						}

						int yc = 1;
						int xc = 0;
						for (int y = 0, x = 0; ; y += yc, x += xc)
						{
							if (x == 0 && y == 0 && yc == 0 && xc == -1)
								break;

							if ((int)colors[y, x].R + (int)colors[y, x].G + (int)colors[y, x].B <= RGBSum / 2)
								colors[y, x] = Color.White;
							else
								colors[y, x] = Color.Black;

							if (y + yc < 0 || y + yc > 7 || x + xc < 0 || x + xc > 7)
							{
								if (yc == 1 && xc == 0)
								{
									yc = 0;
									xc = 1;
								}
								else if (yc == 0 && xc == 1)
								{
									yc = -1;
									xc = 0;
								}
								else if (yc == -1 && xc == 0)
								{
									yc = 0;
									xc = -1;
								}
							}
						}

						for (int y = 0; y < 8; y++)
						{
							for (int x = 0; x < 8; x++)
							{
								img.SetPixel(x + j, y + i, colors[y, x]);
							}
						}
					}
					l++;
					if (form != null)
						form.ChangeProgress((int)(((double)l + 20) / (double)(bitCount + 20) * 100));
				}
				if (l >= bitCount)
					break;
			}
			if (form != null)
				form.ChangeProgress(100);
			return (badEncoded, img);
		}

	}
}
