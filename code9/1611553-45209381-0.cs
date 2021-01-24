	private List<Point> _points;
	private Size _targetarea;
	private void btnGenerate_Click(object sender, RoutedEventArgs e)
	{
		_targetarea = new Size(500, 500);
		_points = GeneratePoints(10000, _targetarea);
		TheImage.Source = DrawPoints(_points, _targetarea, 5, 5, 1);
	}
	private List<Point> GeneratePoints(int count, Size size)
	{
		Random r = new Random();
		return Enumerable.Range(0, count)
			.Select(j => new Point(r.NextDouble() * size.Width, r.NextDouble() * size.Height))
			.ToList();
	}
	private static ImageSource DrawPoints(IEnumerable<Point> points, Size size, double radiusX, double radiusY, double thickness)
	{
		DrawingVisual visual = new DrawingVisual();
		using (DrawingContext context = visual.RenderOpen())
		{
			var fill = new SolidColorBrush(Colors.Yellow);
			var stroke = new SolidColorBrush(Colors.Red);
			foreach(var center in points)
			{
				context.DrawEllipse(fill, new Pen(stroke, thickness), center, radiusX, radiusY);
			}
		}
		RenderTargetBitmap bitmap = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
		bitmap.Render(visual);
		bitmap.Freeze();
		return bitmap;
	}
