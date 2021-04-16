using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCW
{
    public static class Additions
    {
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

        public static void EnterToConsole(this Bitmap arr)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(arr.GetPixel(j, i).B + "\t");
                }
                Console.WriteLine();
            }
        }

        public static byte[] BitArrayToByteArray(this BitArray bitsArray)
        {
            byte[] ret = new byte[bitsArray.Length / 8];

            for (int i = 0; i + 7 < bitsArray.Length; i += 8)
            {
                bool[] boolArray = { bitsArray[i + 7], bitsArray[i + 6], bitsArray[i + 5], bitsArray[i + 4],
                    bitsArray[i + 3], bitsArray[i + 2], bitsArray[i + 1], bitsArray[i]};
                BitArray bits = new BitArray(boolArray);

                bits.CopyTo(ret, i / 8);
            }

            return ret;
        }

        public static Bitmap ResizeBitmap(this Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }
    }
}
