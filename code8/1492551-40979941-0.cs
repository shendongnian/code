    public static BitmapImage Invert(BitmapImage source)
	{
		// Calculate stride of source
		int stride = source.PixelWidth * (source.Format.BitsPerPixel / 8);
		// Create data array to hold source pixel data
		int lenght = stride * source.PixelHeight;
		byte[] data = new byte[lenght];
		// Copy source image pixels to the data array
		source.CopyPixels(data, stride, 0);
		for (int iii = 0; iii < lenght; iii+=4)
		{
			data[iii]  = (byte)(255 - data[iii]);//R
			data[iii+1] = (byte)(255 - data[iii+1]);//G
			data[iii+2] = (byte)(255 -data[iii+2]);//B
			//data[iii+3] = (byte)(255 - data[iii+3]);//A
		}
		// Create WriteableBitmap to copy the pixel data to.      
		WriteableBitmap target = new WriteableBitmap(
				source.PixelWidth,
				source.PixelHeight,
				source.DpiX, source.DpiY,
				source.Format, null);
		// Write the pixel data to the WriteableBitmap.
		target.WritePixels(
				new Int32Rect(0, 0, source.PixelWidth, source.PixelHeight),
				data, stride, 0);
		// Set the WriteableBitmap as the source for the <Image> element 
		// in XAML so you can see the result of the copy
		BitmapImage result = ConvertWriteableBitmapToBitmapImage(target);
		return result;
	}
	public static BitmapImage ConvertWriteableBitmapToBitmapImage(WriteableBitmap wbm)
	{
		var bmp = new BitmapImage();
		using (MemoryStream stream = new MemoryStream())
		{
			PngBitmapEncoder encoder = new PngBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(wbm));
			encoder.Save(stream);
			bmp.BeginInit();
			bmp.CacheOption = BitmapCacheOption.OnLoad;
			bmp.StreamSource = stream;
			bmp.EndInit();
			bmp.Freeze();
		}
	return bmp;
	}
	public static BitmapImage BitmapSource2BitmapImage(BitmapSource bitmapSource)
	{
		JpegBitmapEncoder encoder = new JpegBitmapEncoder();
		MemoryStream memoryStream = new MemoryStream();
		BitmapImage bImg = new BitmapImage();
		encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
		encoder.Save(memoryStream);
		memoryStream.Position = 0;
		bImg.BeginInit();
		bImg.StreamSource = memoryStream;
		bImg.EndInit();
		memoryStream.Close();
		return bImg;
	}
