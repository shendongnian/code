	var size = new CGSize(width, height);
	var rect = new CGRect(new CGPoint(), size);
	NSImage image;
	using (var context = new CGBitmapContext(IntPtr.Zero, width, height, 8, width * 4, NSColorSpace.GenericRGBColorSpace.ColorSpace, CGImageAlphaInfo.PremultipliedFirst))
	{
		context.SetFillColor(NSColor.Red.CGColor);
		context.FillRect(rect);
		using (var cgImage = context.ToImage())
		{
			image = new NSImage(cgImage, size);
		}
	}
