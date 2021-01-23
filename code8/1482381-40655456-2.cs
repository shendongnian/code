	private Pen _leftPen = Pens.Black;
	private Pen _rightPen = Pens.Red;
	
	private List<Point> _leftPoints = new List<Point>();
	private List<Point> _rightPoints = new List<Point>();
	
	private void Form1_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == System.Windows.Forms.MouseButtons.Left)
		{
			_leftPoints.Add(new Point(e.X, e.Y));
		}
		if (e.Button == System.Windows.Forms.MouseButtons.Right)
		{
			_rightPoints.Add(new Point(e.X, e.Y));
		}
	}
	
	private void Form1_Paint(object sender, PaintEventArgs e)
	{
		foreach (Point point in _leftPoints)
		{
			e.Graphics.DrawLine(_leftPen, point.X, point.Y, point.X + 1, point.Y + 1);
		}
		
		//Similar code for _rightPoints here
	}
