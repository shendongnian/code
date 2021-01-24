    if (strikeout)
	{
	   var newText = new NSMutableAttributedString(text.Value);
	   newText.AddAttribute(UIStringAttributeKey.StrikethroughStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single), range);
       label.AttributedText = newText;
	}
	else
	{
        var newText = new NSMutableAttributedString(text.Value);
		label.AttributedText = newText;
	}
