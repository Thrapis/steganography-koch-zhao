using System;
using System.Collections;
using System.Drawing;

namespace TestCW
{
    /// <summary>
    /// Класс методов расширения
    /// </summary>
    public static class Additions
    {
        /// <summary>
        /// Вывод на консоль массива байт
        /// </summary>
        public static void EnterToConsole(this byte[,] arr)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Вывод на консоль массива чисел с двойной точностью
        /// </summary>
        public static void EnterToConsole(this double[,] arr)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(Math.Round(arr[i, j], 2) + "\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Вывод на консоль спектр изображения
        /// </summary>
        public static void EnterToConsole(this Bitmap arr, Spectrum spectrum)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    switch (spectrum)
                    {
                        case Spectrum.Red:
                            Console.Write(arr.GetPixel(j, i).R + "\t");
                            break;
                        case Spectrum.Green:
                            Console.Write(arr.GetPixel(j, i).G + "\t");
                            break;
                        case Spectrum.Blue:
                            Console.Write(arr.GetPixel(j, i).B + "\t");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Конвертирование массива бит в массив байт
        /// </summary>
        public static byte[] BitArrayToByteArray(this BitArray bitsArray)
        {
            byte[] result = new byte[bitsArray.Length / 8];

            for (int i = 0; i + 7 < bitsArray.Length; i += 8)
            {
                bool[] boolArray = { bitsArray[i + 7], bitsArray[i + 6], bitsArray[i + 5], bitsArray[i + 4],
                    bitsArray[i + 3], bitsArray[i + 2], bitsArray[i + 1], bitsArray[i]};
                BitArray bits = new BitArray(boolArray);

                bits.CopyTo(result, i / 8);
            }

            return result;
        }

        /// <summary>
        /// Изменение размера изображения
        /// </summary>
        public static Bitmap ResizeBitmap(this Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        /// <summary>
        /// Копирование двумерного массива чисел
        /// </summary>
        public static double[,] Copy(this double[,] arr)
        {
            double[,] result = new double[arr.GetLength(0), arr.GetLength(1)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    result[i, j] = arr[i, j];
                }
            }

            return result;
        }
    }
}
