    StringBuilder sbItems = FillStringBuilder(...);
    // before copying, remove a possible new line character
    // for this we use property System.Environment.NewLine
    var stringToCopyToClipboard = sbItems.ToString();
    if (stringToCopyToClipboard.EndsWith(Environment.NewLine)
    {
        int newLineIndex = stringToCopyToClipboard.LastIndexOf(Environment.NewLine);
        stringToCopyToClipboard = stringToCopyToClipboard.Substring(0, newLineIndex);
    }
    Clipboard.SetText(stringToCopyToClipboard);
