    public static unsafe void CopyBitmap(Bitmap from, Bitmap to, Rectangle destRect, Rectangle srcRect)
    {
		//Check rects line up appropriatley
				
		//You should get this and the PixelFormat's of the images properly
		//unless you can alsways assume the same format
		const int BYTES_PER_PIXEL = 4;
		
        BitmapData fromData = from.LockBits(srcRect, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
		try
		{
			BitmapData toData = to.LockBits(destRect, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
			try
			{
				//For the purpose of this example I will assume that srcRect and destRect are the same
				//You will need to do the offset code yourself
				
				for (int hi = srcRect.Y, hc = scrRect.Bottom; hi < hc; ++hi)
				{
					byte* fromRow = (byte*)fromData.Scan0 + (hi * fromData.Stride);
					byte* toRow = (byte*)toData.Scan0 + (hi * toData.Stride);
					for (int wi = (srcRect.X * BYTES_PER_PIXEL), wc = (srcRect.Right * BYTES_PER_PIXEL);
						 wi < wc; wi += BYTES_PER_PIXEL)
					{
						//Adject this if you have a different format
						
						toRow[wi] = fromRow[wi];
						toRow[wi + 1] = fromRow[wi + 1];
						toRow[wi + 2] = fromRow[wi + 2];
						toRow[wi + 3] = fromRow[wi + 3];
					}
				}
			}
			finally
			{
				to.UnlockBits(fromData);
			}
		}
		finally
		{
			from.UnlockBits(fromData);
		}
    }
