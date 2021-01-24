	private void ColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
	{
		Graphics g = e.Graphics;
		Rectangle rect = e.Bounds;
		if (e.Index >= 0)
		{
		   Color c = Color.FromName(n);
		   Brush b = new SolidBrush(c);
		   g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
		   g.FillRectangle(b, rect.X, rect.Y + 5, rect.Width -10, rect.Height - 10);
		}
	}
