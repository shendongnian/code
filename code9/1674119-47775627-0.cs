	public static Bitmap CropTransparentPixels(this Bitmap bmp)
	{
		BitmapData bmData = null;
		try
		{
			bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			int scanline = bmData.Stride;
			IntPtr Scan0 = bmData.Scan0;
			Point top = new Point(), left = new Point(), right = new Point(), bottom = new Point();
			bool complete = false;
			unsafe
			{
				byte* p = (byte*)(void*)Scan0;
				for (int y = 0; y < bmp.Height; y++)
				{
					for (int x = 0; x < bmp.Width; x++)
					{
						if (p[3] != 0)
						{
							top = new Point(x, y);
							complete = true;
							break;
						}
						p += 4;
					}
					if (complete)
						break;
				}
				p = (byte*)(void*)Scan0;
				complete = false;
				for (int y = bmp.Height - 1; y >= 0; y--)
				{
					for (int x = 0; x < bmp.Width; x++)
					{
						if (p[x * 4 + y * scanline + 3] != 0)
						{
							bottom = new Point(x + 1, y + 1);
							complete = true;
							break;
						}
					}
					if (complete)
						break;
				}
				p = (byte*)(void*)Scan0;
				complete = false;
				for (int x = 0; x < bmp.Width; x++)
				{
					for (int y = 0; y < bmp.Height; y++)
					{
						if (p[x * 4 + y * scanline + 3] != 0)
						{
							left = new Point(x, y);
							complete = true;
							break;
						}
					}
					if (complete)
						break;
				}
				p = (byte*)(void*)Scan0;
				complete = false;
				for (int x = bmp.Width - 1; x >= 0; x--)
				{
					for (int y = 0; y < bmp.Height; y++)
					{
						if (p[x * 4 + y * scanline + 3] != 0)
						{
							right = new Point(x + 1, y + 1);
							complete = true;
							break;
						}
					}
					if (complete)
						break;
				}
			}
			bmp.UnlockBits(bmData);
			System.Drawing.Rectangle rectangle = new Rectangle(left.X, top.Y, right.X - left.X, bottom.Y - top.Y);
			Bitmap b = new Bitmap(rectangle.Width, rectangle.Height);
			Graphics g = Graphics.FromImage(b);
			g.DrawImage(bmp, 0, 0, rectangle, GraphicsUnit.Pixel);
			g.Dispose();
			return b;
		}
		catch
		{
			return null;
		}
		finally
		{
			bmp.UnlockBits(bmData);
		}
	}
