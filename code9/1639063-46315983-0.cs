	protected override void OnPaint(PaintEventArgs e)
	{
		Rectangle rect = ClientRectangle;
		using (SolidBrush brush = new SolidBrush(BackColor))
			e.Graphics.FillRectangle(brush, rect);
		e.Graphics.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width - 2, rect.Height - 2);
		rect.Inflate(-3, -3);
		if (Value > 0)
		{
			Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);
			using (SolidBrush brush = new SolidBrush(ForeColor))
				e.Graphics.FillRectangle(brush, clip);
		}
		using (Font f = new Font(sgvDesigner.FontFamily, 12))
		{
			String text = getDisplayText();
			SizeF len = e.Graphics.MeasureString(text, f);
			Point location = new Point(Convert.ToInt32((Width / 2) - len.Width / 2), Convert.ToInt32((Height / 2) - len.Height / 2));
			e.Graphics.DrawString(text, f, TextColor, location);
		}
		return;
	}
