	public struct Point
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Point(int x, int y) { X = x; Y = y; }
		public static Point operator +(Point left, Point right)
			=> new Point(left.X + right.X, left.Y + right.Y);
	}
	
