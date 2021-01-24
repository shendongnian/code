    var context = UIGraphics.GetCurrentContext();
    CGRect textRect = new CGRect(0.0f, 0.0f, 200.0f, 100.0f);
    {
        var textContent = "Hello\nHow are you?\nSincerely,\nStackOverflow";
        UIColor.Red.SetFill();
        var textStyle = new NSMutableParagraphStyle ();
        textStyle.Alignment = UITextAlignment.Left;
    
        var textFontAttributes = new UIStringAttributes () {Font = UIFont.FromName("ArialMT", 16.0f), ForegroundColor = UIColor.Red, ParagraphStyle = textStyle};
        var textTextHeight = new NSString(textContent).GetBoundingRect(new CGSize(textRect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, textFontAttributes, null).Height;
        context.SaveState();
        context.ClipToRect(textRect);
        new NSString(textContent).DrawString(new CGRect(textRect.GetMinX(), textRect.GetMinY() + (textRect.Height - textTextHeight) / 2.0f, textRect.Width, textTextHeight), UIFont.FromName("ArialMT", 16.0f), UILineBreakMode.WordWrap, UITextAlignment.Left);
        context.RestoreState();
    }
