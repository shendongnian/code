	public Bitmap AppendBitmap(Bitmap source, Bitmap target, int spacing)
	{
		int w = Math.Max(source.Width, target.Width);
		int h = source.Height + target.Height + spacing;
		Bitmap bmp = new Bitmap(w, h);
		using (Graphics g = Graphics.FromImage(bmp))
		{
			g.DrawImage(source, 0, 0);
			g.DrawImage(target, 0, source.Height + spacing);
		}
		return bmp;
	}
