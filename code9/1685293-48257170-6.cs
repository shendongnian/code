    //Define some useful flags for TextRenderer
    TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.Top | 
                            TextFormatFlags.NoPadding | TextFormatFlags.WordBreak | 
                            TextFormatFlags.TextBoxControl;
    //The char to look for
    char TheChar = 't';
    //Find all 't' chars indexes in the text
    List<int> TheIndexList = textBox1.Text.Select((chr, idx) => chr == TheChar ? idx : -1)
                                          .Where(idx => idx != -1).ToList();
    //Or with Regex - same thing, pick the one you like best
    List<int> TheIndexList = Regex.Matches(textBox1.Text, TheChar.ToString())
                                  .Cast<Match>()
                                  .Select(chr => chr.Index).ToList();
    //Using .GetPositionFromCharIndex(), define the Point [p] where the highlighted text is drawn
    if (TheIndexList.Count > 0)
    {
        foreach (int Position in TheIndexList)
        {
            Point p = textBox1.GetPositionFromCharIndex(Position);
            using (Graphics g = textBox1.CreateGraphics())
                   TextRenderer.DrawText(g, TheChar.ToString(), textBox1.Font, p,
                                         textBox1.ForeColor, Color.LightGreen, flags);
        }
    }
