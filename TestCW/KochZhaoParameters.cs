using System.Drawing;

namespace TestCW
{
	/// <summary>
	/// Структура параметров для алгоритма Коха-Жао
	/// </summary>
	public struct KochZhaoParameters
    {
		public Point P1;
		public Point P2;
		public int Offset;
		public Spectrum Spectrum;

        public KochZhaoParameters(Point p1, Point p2, int offset = 25, Spectrum spectrum = Spectrum.Blue)
        {
            Offset = offset;
            Spectrum = spectrum;
			if (p1.X >= 0 && p1.X <= 7 && p1.Y >= 0 && p1.Y <= 7)
				P1 = p1;
			else
				P1 = new Point(3, 4);
			if (p2.X >= 0 && p2.X <= 7 && p2.Y >= 0 && p2.Y <= 7)
				P2 = p2;
			else
				P2 = new Point(4, 3);
		}

		/// <summary>
		/// Установить все параметры
		/// </summary>
		public void SetParameters(Point p1, Point p2, int offset, Spectrum spectrum)
		{
			Offset = offset;
			Spectrum = spectrum;
			if (p1.X >= 0 && p1.X <= 7 && p1.Y >= 0 && p1.Y <= 7)
				P1 = p1;
			if (p2.X >= 0 && p2.X <= 7 && p2.Y >= 0 && p2.Y <= 7)
				P2 = p2;
		}

		/// <summary>
		/// Получить все параметры
		/// </summary>
		public (Point, Point, int, Spectrum) GetParameters()
		{
			return (P1, P2, Offset, Spectrum);
		}
	}
}
