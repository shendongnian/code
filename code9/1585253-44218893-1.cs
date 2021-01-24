	public unsafe void Threshold(Bitmap bmp, int thresh)
	{
		var bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
		var bitsPerPixel = Image.GetPixelFormatSize(bmp.PixelFormat);
		var p = (byte*)bmData.Scan0.ToPointer();
		for (int i = 0; i < bmData.Height; ++i)
		{
			for (int j = 0; j < bmData.Width; ++j)
			{
				byte* data = p + i * bmData.Stride + j * bitsPerPixel / 8;
				data[0] = (byte)((data[0] > thresh) ? 255 : 0);
				data[1] = (byte)((data[1] > thresh) ? 255 : 0);
				data[2] = (byte)((data[2] > thresh) ? 255 : 0);
			}
		}
		bmp.UnlockBits(bmData);
