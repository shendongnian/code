    using (Image image = Image.FromFile(WaferMapHistogramFileName))
	using (Graphics g = Graphics.FromImage(image))
    {
        g.DrawLine(blackPen, P1, P2);
		
		image.Save(@"Save somewhere, here: WaferMapHistogramFileName?");
    }
