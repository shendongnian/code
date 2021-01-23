	public static void SaveByteArryToJpeg(string imagePath, Byte[] data, int width, int height)
	{
		if (width * height != data.Length)
			throw new FormatException("Size does not match");
		Bitmap bmp = new Bitmap(width, height);
		for (int r = 0; r < height; r++)
		{
			for (int c = 0; c < width; c++)
			{
				Byte value = data[r * width + c];
				bmp.SetPixel(c, r, Color.FromArgb(value, value, value));
			}
		}
		bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
	}
