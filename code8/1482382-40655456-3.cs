	private Pen _leftPen = Pens.Black;
	private Pen _rightPen = Pens.Red;
	
	private void Form1_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == System.Windows.Forms.MouseButtons.Left)
		{
			Graphics graphic = this.CreateGraphics();
			graphic.DrawLine(_leftPen, e.X, e.Y, e.X + 1, e.Y + 1);
		}
		if (e.Button == System.Windows.Forms.MouseButtons.Right)
		{
			Graphics graphic = this.CreateGraphics();
			graphic.DrawLine(_rightPen, e.X, e.Y, e.X + 1, e.Y + 1);
		}
	}
