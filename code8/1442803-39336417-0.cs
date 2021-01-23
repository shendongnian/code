    private void YourMethod()
    {
        Process("[txtItalic]This is italic[/txtItalic], this is normal, [txtBold]Bold Text[/txtBold] and now [txtUnderline]Underlined Text[/txtUnderline]. The end.");
    }
    private void Process(string textWithTags)
    {
        MatchCollection matches = Regex.Matches(textWithTags, @"\[(\w*)\](.*)\[\/\1\]");
            
        int unformattedStartPosition = 0;
        int unformattedEndPosition = 0;
        foreach (Match item in matches)
        {
            unformattedEndPosition = textWithTags.IndexOf(item.Value);
            // Add unformatted text.
            AddText(textWithTags.Substring(unformattedStartPosition, unformattedEndPosition - unformattedStartPosition), FontStyle.Regular);
            // Add formatted text.
            FontStyle style = GetStyle(item.Groups[1]);
            AddText(item.Groups[2].Value, style);
            unformattedStartPosition = unformattedEndPosition + item.Value.Length;
        }
        AddText(textWithTags.Substring(unformattedStartPosition), FontStyle.Regular);
    }
    private FontStyle GetStyle(Group group)
    {
        switch (group.Value)
        {
            case "txtItalic":
                return FontStyle.Italic;
            case "txtBold":
                return FontStyle.Bold;
            case "txtUnderline":
                return FontStyle.Underline;
            default:
                return FontStyle.Regular;
        }
    }
    private void AddText(string text, FontStyle style)
    {
        if (text.Length == 0)
            return;
        richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, style);
        richTextBox.AppendText(text);
    }
