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
		private static int Offset = 25;
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

		public static double[,] GetDCT(double[,] temp_bm)
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

		public static double[,] GetIDCT(double[,] dct)
		{
			double[,] arr = new double[8, 8];

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
							//byte spect = temp > 255 ? (byte)255 : (byte)Math.Round(temp);
							arr[i, j] = temp;
						}
					}
				}
			}
			return arr;
		}

		private static byte[,] Normalization(double[,] idct)
		{
			double min = Double.MaxValue, max = Double.MinValue;
			for (int i = 0; i < idct.GetLength(0); i++)
			{
				for (int j = 0; j < idct.GetLength(1); j++)
				{
					if (idct[i, j] > max)
						max = idct[i, j];
					if (idct[i, j] < min)
						min = idct[i, j];
				}
			}
			byte[,] result = new byte[idct.GetLength(0), idct.GetLength(1)];
			for (int i = 0; i < idct.GetLength(0); i++)
			{
				for (int j = 0; j < idct.GetLength(1); j++)
				{
					result[i, j] = (byte)(255 * (idct[i, j] + Math.Abs(min)) / (max + Math.Abs(min)));
				}
			}
			return result;
		}

		private static double[,] SetBitToSqrOctoplet(double[,] dct, bool bit)
		{
			double k;
			double[,] buf_dct = dct.Copy();

			bool good_idct = false;
			while (!good_idct)
			{
				bool encr_bit = false;
				while (!encr_bit)
				{
					k = Math.Abs(buf_dct[P1.Y, P1.X]) - Math.Abs(buf_dct[P2.Y, P2.X]);
					if (bit) // K1 - K2 > Offset    ->   1
					{
						if (k <= Offset)
						{
							buf_dct[P1.Y, P1.X] += buf_dct[P1.Y, P1.X] >= 0 ? 1 : -1;
							buf_dct[P2.Y, P2.X] += buf_dct[P2.Y, P2.X] >= 0 ? -1 : 1;
						}
						else
							encr_bit = true;
					}
					else            // K1 - K2 < -Offset     ->   0
					{
						if (k >= -Offset)
						{
							buf_dct[P1.Y, P1.X] += buf_dct[P1.Y, P1.X] >= 0 ? -1 : 1;
							buf_dct[P2.Y, P2.X] += buf_dct[P2.Y, P2.X] >= 0 ? 1 : -1;
						}
						else
							encr_bit = true;
					}
				}
				double[,] decr_dct = GetDCT(GetIDCT(buf_dct));
				k = Math.Abs(decr_dct[P1.Y, P1.X]) - Math.Abs(decr_dct[P2.Y, P2.X]);
				if (bit) // K1 - K2 > Offset    ->   1
				{
					if (k >= 0)
						good_idct = true;
					else
						buf_dct = decr_dct;
				}
				else            // K1 - K2 < -Offset     ->   0
				{
					if (k < 0)
						good_idct = true;
					else
						buf_dct = decr_dct;
				}
			}
			return buf_dct;
		}

		public static Bitmap Encode(Bitmap toCloneImg, Encoding encoding, string text, int selectedSpecter, IProgressChanged form = null, bool pixelCorrection = false)
        {
            if (form != null)
                form.ChangeProgress(5);

            Random rand = new Random();
            BitArray textBits = ToBinaryString(encoding, text);
            Bitmap img = (Bitmap)toCloneImg.Clone();
            int l = 0;

            if (form != null)
                form.ChangeProgress(20 / (textBits.Count + 20) * 100);

            double[,] specter_map = GetSpecterMap(selectedSpecter, ref img);

            double[,] temp_bm = new double[8, 8];
            for (int i = 0; i + 7 < img.Height; i += 8)
            {
                for (int j = 0; j + 7 < img.Width; j += 8)
                {
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

                    bool bit;
                    if (l < textBits.Count)
                        bit = textBits[l];
                    else
                        bit = rand.Next(0, 2) == 1 ? true : false;

                    dct = SetBitToSqrOctoplet(dct, bit);

                    temp_bm = GetIDCT(dct);

                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            specter_map[x + j, y + i] = temp_bm[x, y];
                        }
                    }

                    if (l < textBits.Count)
                        l++;
                    if (form != null)
                        form.ChangeProgress((int)(((double)l + 20) / (double)(textBits.Count + 20) * 100 / 2));
                }
            }

            byte[,] normalized_specter_map = Normalization(specter_map);

            SetSpecterMapOfImage(selectedSpecter, ref img, normalized_specter_map);

            if (form != null)
                form.ChangeProgress(100);
            return img;
        }

        private static void SetSpecterMapOfImage(int selectedSpecter, ref Bitmap img, byte[,] normalized_specter_map)
        {
            for (int i = 0; i + 7 < img.Height; i += 8)
            {
                for (int j = 0; j + 7 < img.Width; j += 8)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            Color old = img.GetPixel(x + j, y + i);
                            Color cl = new Color();
                            if (selectedSpecter == 0)
                                cl = Color.FromArgb(normalized_specter_map[x + j, y + i], old.G, old.B);
                            else if (selectedSpecter == 1)
                                cl = Color.FromArgb(old.R, normalized_specter_map[x + j, y + i], old.B);
                            else if (selectedSpecter == 2)
                                cl = Color.FromArgb(old.R, old.G, normalized_specter_map[x + j, y + i]);
                            img.SetPixel(x + j, y + i, cl);
                        }
                    }
                }
            }
        }

        private static double[,] GetSpecterMap(int selectedSpecter, ref Bitmap img)
        {
            double[,] specter_map = new double[img.Width, img.Height];
            for (int i = 0; i + 7 < img.Height; i += 8)
            {
                for (int j = 0; j + 7 < img.Width; j += 8)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            Color cl = img.GetPixel(x + j, y + i);
                            if (selectedSpecter == 0)
                                specter_map[x + j, y + i] = cl.R;
                            else if (selectedSpecter == 1)
                                specter_map[x + j, y + i] = cl.G;
                            else if (selectedSpecter == 2)
                                specter_map[x + j, y + i] = cl.B;
                        }
                    }
                }
            }
            return specter_map;
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

			double[,] temp_bm = new double[8, 8];
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
