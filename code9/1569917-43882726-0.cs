    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = true)]
	public static extern void CopyMemoryUnmanaged(IntPtr dest, IntPtr src, int count);
    // in case you can't use P/Invoke, copy via intermediate .Net buffer		
	static void CopyMemoryNet(IntPtr dst, IntPtr src, int count)
	{
		byte[] buffer = new byte[count];
		Marshal.Copy(src, buffer, 0, count);
		Marshal.Copy(buffer, 0, dst, count);
	}
	static Image CopyImagePart(Bitmap srcImg, int startH, int endH)
	{
		var width = srcImg.Width;
		var height = endH - startH;
		var srcBitmapData = srcImg.LockBits(new Rectangle(0, startH, width, height), ImageLockMode.ReadOnly, srcImg.PixelFormat);
		var dstImg = new Bitmap(width, height, srcImg.PixelFormat);
		var dstBitmapData = dstImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, srcImg.PixelFormat);
		int bytesCount = Math.Abs(srcBitmapData.Stride) * height;
		CopyMemoryUnmanaged(dstBitmapData.Scan0, srcBitmapData.Scan0, bytesCount);
        // in case you can't use P/Invoke, copy via intermediate .Net buffer		
        //CopyMemoryNet(dstBitmapData.Scan0, srcBitmapData.Scan0, bytesCount);
		srcImg.UnlockBits(srcBitmapData);
		dstImg.UnlockBits(dstBitmapData);
		return dstImg;
	}
	public static Image ResizeInParts(Bitmap srcBmp, int width, int height)
	{
		int srcStep = srcBmp.Height;
		int dstStep = height;
		while (srcStep > 30000)
		{
			srcStep /= 2;
			dstStep /= 2;
		}
		var resBmp = new Bitmap(width, height);
		using (Graphics graphic = Graphics.FromImage(resBmp))
		{
			graphic.InterpolationMode = InterpolationMode.NearestNeighbor;
			graphic.PixelOffsetMode = PixelOffsetMode.Half;
			for (int srcTop = 0, dstTop = 0; srcTop < srcBmp.Height; srcTop += srcStep, dstTop += dstStep)
			{
				int srcBottom = srcTop + srcStep;
				int dstH = dstStep;
				if (srcBottom > srcBmp.Height)
				{
					srcBottom = srcBmp.Height;
					dstH = height - dstTop;
				}
				using (var imgPart = CopyImagePart(srcBmp, srcTop, srcBottom))
				{
					graphic.DrawImage(imgPart, 0, dstTop, width, dstH);
				}
			}
		}
		return resBmp;
	}
