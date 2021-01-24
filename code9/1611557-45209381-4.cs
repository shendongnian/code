	private static ImageSource DrawPoints(IEnumerable<Point> points, Size size, double radiusX, double radiusY, double thickness)
	{
		WriteableBitmap bitmap = new WriteableBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32, null);
		foreach(var center in points)
		{
			bitmap.FillEllipse((int)(center.X - radiusX), (int)(center.Y - radiusY), (int)(center.X + radiusX), (int)(center.Y + radiusY), Colors.Yellow);
			bitmap.DrawEllipse((int) (center.X - radiusX), (int) (center.Y - radiusY), (int) (center.X + radiusX), (int) (center.Y + radiusY), Colors.Red);
		}
		bitmap.Freeze();
		return bitmap;
	}
