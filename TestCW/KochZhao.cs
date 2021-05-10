using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TestCW
{
	/// <summary>
	/// Класс стеганографического алгоритма Коха-Жао
	/// </summary>
	public static class KochZhao
	{
		private const int RGBSum = 255 + 255 + 255;

		/// <summary>
		/// Преобразование текста в массив бит в указанной кодировке
		/// </summary>
		private static BitArray StringToBinary(Encoding encoding, string text)
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

		/// <summary>
		/// Преобразование массива бит в текст в указанной кодировке
		/// </summary>
		private static string BinaryToString(Encoding encoding, BitArray bitArray)
		{
			return encoding.GetString(bitArray.BitArrayToByteArray());
		}

		/// <summary>
		/// Пулучить дискретное косинусное пребразование
		/// </summary>
		private static double[,] GetDCT(double[,] temp_bm)
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

		/// <summary>
		/// Получить обратное дискретное косинусное предобразование
		/// </summary>
		private static double[,] GetIDCT(double[,] dct)
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
							arr[i, j] = temp;
						}
					}
				}
			}
			return arr;
		}

		/// <summary>
		/// Нормализвация обратного дискретного косинусного предобразования
		/// </summary>
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

		/// <summary>
		/// Установить бит в область дискретного косинусного преобразования с проверкой извлекаемости
		/// </summary>
		private static double[,] SetBitToSqrOctoplet(double[,] dct, bool bit, KochZhaoParameters parameters)
		{
			int offset = parameters.Offset;
			Point p1 = parameters.P1;
			Point p2 = parameters.P2;

			double k;
			double[,] buf_dct = dct.Copy();

			bool good_idct = false;
			while (!good_idct)
			{
				bool encr_bit = false;
				while (!encr_bit)
				{
					k = Math.Abs(buf_dct[p1.Y, p1.X]) - Math.Abs(buf_dct[p2.Y, p2.X]);
					if (bit)
					{
						if (k <= offset)
						{
							buf_dct[p1.Y, p1.X] += buf_dct[p1.Y, p1.X] >= 0 ? 1 : -1;
							buf_dct[p2.Y, p2.X] += buf_dct[p2.Y, p2.X] >= 0 ? -1 : 1;
						}
						else
							encr_bit = true;
					}
					else
					{
						if (k >= -offset)
						{
							buf_dct[p1.Y, p1.X] += buf_dct[p1.Y, p1.X] >= 0 ? -1 : 1;
							buf_dct[p2.Y, p2.X] += buf_dct[p2.Y, p2.X] >= 0 ? 1 : -1;
						}
						else
							encr_bit = true;
					}
				}
				double[,] decr_dct = GetDCT(GetIDCT(buf_dct));
				k = Math.Abs(decr_dct[p1.Y, p1.X]) - Math.Abs(decr_dct[p2.Y, p2.X]);
				if (bit)
				{
					if (k >= 0)
						good_idct = true;
					else
						buf_dct = decr_dct;
				}
				else
				{
					if (k < 0)
						good_idct = true;
					else
						buf_dct = decr_dct;
				}
			}
			return buf_dct;
		}

		/// <summary>
		/// Установить бит в область дискретного косинусного преобразования без проверки извлекаемости
		/// </summary>
		private static double[,] SetBitToSqrOctopletLight(double[,] dct, bool bit, KochZhaoParameters parameters)
		{
			int Offset = parameters.Offset;
			Point P1 = parameters.P1;
			Point P2 = parameters.P2;

			double k;
			double[,] buf_dct = dct.Copy();

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
			return buf_dct;
		}

		/// <summary>
		/// Установить спектр в изображение
		/// </summary>
		private static void SetSpectrumMapOfImage(Spectrum spectrum, ref Bitmap img, byte[,] normalized_specter_map)
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
                            if (spectrum == Spectrum.Red)
                                cl = Color.FromArgb(normalized_specter_map[x + j, y + i], old.G, old.B);
                            else if (spectrum == Spectrum.Green)
                                cl = Color.FromArgb(old.R, normalized_specter_map[x + j, y + i], old.B);
                            else if (spectrum == Spectrum.Blue)
                                cl = Color.FromArgb(old.R, old.G, normalized_specter_map[x + j, y + i]);
                            img.SetPixel(x + j, y + i, cl);
                        }
                    }
                }
            }
        }

		/// <summary>
		/// Получить спектр изображения
		/// </summary>
		private static double[,] GetSpectrumMap(Spectrum spectrum, ref Bitmap img)
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
                            if (spectrum == Spectrum.Red)
                                specter_map[x + j, y + i] = cl.R;
                            else if (spectrum == Spectrum.Green)
                                specter_map[x + j, y + i] = cl.G;
                            else if (spectrum == Spectrum.Blue)
                                specter_map[x + j, y + i] = cl.B;
                        }
                    }
                }
            }
            return specter_map;
        }

		/// <summary>
		/// Закодировать сообщение в изображение
		/// </summary>
		public static Bitmap Encode(Bitmap toCloneImg, Encoding encoding, string text, KochZhaoParameters parameters, IProgressChanged form = null)
		{
			Spectrum spectrum = parameters.Spectrum;

			if (form != null)
				form.ChangeProgress(1);

			Random rand = new Random();
			BitArray textBits = StringToBinary(encoding, text);
			Bitmap img = (Bitmap)toCloneImg.Clone();
			int l = 0;
			int MaxEncodedBits = (img.Width / 8) * (img.Height / 8);

			double[,] spectrum_map = GetSpectrumMap(spectrum, ref img);

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
							if (spectrum == Spectrum.Red)
								temp_bm[x, y] = cl.R;
							else if (spectrum == Spectrum.Green)
								temp_bm[x, y] = cl.G;
							else if (spectrum == Spectrum.Blue)
								temp_bm[x, y] = cl.B;
						}
					}

					double[,] dct = GetDCT(temp_bm);

					bool bit;
					if (l < textBits.Count)
                    {
						bit = textBits[l];
						dct = SetBitToSqrOctoplet(dct, bit, parameters);
					}
					else
                    {
						bit = rand.Next(0, 2) == 1 ? true : false;
						dct = SetBitToSqrOctopletLight(dct, bit, parameters);
					}
						
					temp_bm = GetIDCT(dct);

					for (int y = 0; y < 8; y++)
					{
						for (int x = 0; x < 8; x++)
						{
							spectrum_map[x + j, y + i] = temp_bm[x, y];
						}
					}

					l++;
					if (form != null)
						form.ChangeProgress((int)(((double)l / (double)(MaxEncodedBits) * 100)));
				}
			}

			byte[,] normalized_specter_map = Normalization(spectrum_map);

			SetSpectrumMapOfImage(spectrum, ref img, normalized_specter_map);

			if (form != null)
				form.ChangeProgress(100);
			return img;
		}

		/// <summary>
		/// Декодировать сообщение из изображения
		/// </summary>
		public static string Decode(Bitmap toCloneImg, Encoding encoding, int key, KochZhaoParameters parameters, IProgressChanged form = null)
		{
			Spectrum spectrum = parameters.Spectrum;
			Point p1 = parameters.P1;
			Point p2 = parameters.P2;

			if (form != null)
				form.ChangeProgress(1);

			Bitmap img = (Bitmap)toCloneImg.Clone();

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
							if (spectrum == Spectrum.Red)
								temp_bm[x, y] = cl.R;
							else if (spectrum == Spectrum.Green)
								temp_bm[x, y] = cl.G;
							else if (spectrum == Spectrum.Blue)
								temp_bm[x, y] = cl.B;
						}
					}

					double[,] dct = GetDCT(temp_bm);

					if (Math.Abs(dct[p1.Y, p1.X]) > Math.Abs(dct[p2.Y, p2.X]))
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

			string text = BinaryToString(encoding, new BitArray(textBits.ToArray()));

			if (form != null)
				form.ChangeProgress(100);
			return text;
		}

		/// <summary>
		/// Обнаружить и отобразить на изображении неверно декодированные биты. Результатом явлется количество неверных битов и изображение с их обозначением
		/// </summary>
		public static (int, Bitmap) DetectInvalideSqrOctopixels(Bitmap toCloneImg, Encoding encoding, string encodeText, string decodeText, int key, IProgressChanged form = null)
		{
			if (form != null)
				form.ChangeProgress(5);

			Bitmap img = (Bitmap)toCloneImg.Clone();

			Color[,] colors = new Color[8, 8];
			int l = 0;
			int badEncoded = 0;
			int bitCount = key * 8;

			BitArray encodeTextBits = StringToBinary(encoding, encodeText);
			BitArray decodeTextBits = StringToBinary(encoding, decodeText);

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
