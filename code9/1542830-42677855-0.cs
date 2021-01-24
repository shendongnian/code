	private void DoPrintingLogic(Graphics g, string text)    
	{
		const Point startPos = new Point(10, 10);
		SizeF stringSize = g.MeasureString(text, this.Font);
		
		using (SolidBrush redBrush = new SolidBrush(Colors.Red))
		{
			g.DrawLine(Pens.Red, startPos.X, startPos.Y, startPos.X, startPos.Y + stringSize.Height);
			g.DrawString(text, this.Font, redBrush, startPos.X, startPos.Y);
			g.DrawLine(Pens.Red, startPos.X + stringSize.Width, startPos.Y, startPos.X + stringSize.Width, startPos.Y + stringSize.Height);
		}
	}
