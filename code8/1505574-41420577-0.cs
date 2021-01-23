	using (var bmp = new Bitmap(100, 100))
	{
		using (var g = Graphics.FromImage(bmp))
		{
			//Note that this enabled anti-aliasing
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.Clear(Color.White);
			float x = 20.0f;
			float y1 = 1.0f;
			float y2 = 10.0f;
			g.DrawLine(Pens.Red, x, y1, x, y2);
			x = 20.5f;
			y1 = 11.0f;
			y2 = 20.0f;
			g.DrawLine(Pens.Red, x, y1, x, y2);
			x = 21.0f;
			y1 = 21.0f;
			y2 = 30.0f;
			g.DrawLine(Pens.Red, x, y1, x, y2);
		}
	}
