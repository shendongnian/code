	using (var surface = SKSurface.Create(resizedWidth, resizedHeight,
	    SKImageInfo.PlatformColorType, SKAlphaType.Premul))
	using (var paint = new SKPaint())
	{
		// high quality with antialiasing
		paint.IsAntialias = true;
		paint.FilterQuality = SKFilterQuality.High;
		// draw the bitmap to fill the surface
		surface.Canvas.DrawImage(srcImg, new SKRectI(0, 0, resizedWidth, resizedHeight),
			paint);
		surface.Canvas.Flush();
		using (var newImg = surface.Snapshot())
		{
			// do something with newImg
		}
	}
