	int maxWidth = 768;
	int maxHeight = 1004;
	
	using (Bitmap bitmap = new Bitmap(filePath))
	{
		int width = (int)(bitmap.Width * (maxHeight / (float)bitmap.Height));
		int height = maxHeight;
		if (bitmap.Height * (maxWidth / (float)bitmap.Width) <= maxHeight)
		{
			width = maxWidth;
			height = (int)(bitmap.Height * (maxWidth / (float)bitmap.Width));
		}
		using (Bitmap resizedBitmap = new Bitmap(width, height))
		{
			resizedBitmap.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);
			using (Graphics g = Graphics.FromImage(resizedBitmap))
			{
				g.DrawImage(bitmap, 0, 0, resizedBitmap.Width, resizedBitmap.Height);
			}
            //Use resizedBitmap here
		}
	}
