	public class PathControl : NControlView
	{
		public IEnumerable<PathOp> Path { get; set; }
		public override void Draw(ICanvas canvas, Rect rect)
		{
			if (Path != null)
				canvas.DrawPath(Path, new Pen(Colors.Red, 5));
		}
	}
