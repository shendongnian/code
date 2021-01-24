	public override void Draw(CGRect rect)
	{
		var context = UIGraphics.GetCurrentContext();
		context.ScaleCTM(1, -1); // you flipped the context, now you must use negative Y values to draw "into" the view
		var textHeight = new CTFont("Arial", 16).CapHeightMetric; // lets use the actaul height of the font captials.
		DrawText(context, "Hello", textHeight, 0, 0);
		DrawText(context, "How are you?", textHeight, 0, 20);
		DrawText(context, "Sincerely,", textHeight, 0, 40);
		DrawText(context, "StackOverflow,", textHeight, 0, 60);
	}
    void DrawText(CGContext context, string text, nfloat textHeight, nfloat x, nfloat y)
	{
		context.TranslateCTM(-x, -(y + textHeight));
		context.SetFillColor(UIColor.Red.CGColor);
		var attributedString = new NSAttributedString(text,
			new CTStringAttributes
			{
				ForegroundColorFromContext = true,
				Font = new CTFont("Arial", 16)
			});
		CGRect sizeOfText;
		using (var textLine = new CTLine(attributedString))
		{
			textLine.Draw(context);
			sizeOfText = textLine.GetBounds(CTLineBoundsOptions.UseOpticalBounds);
        }
		// Reset the origin back to where is was
		context.TranslateCTM(x - sizeOfText.Width, y + sizeOfText.Height); 
	}
