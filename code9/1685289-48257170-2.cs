    string[] TheStrings = {"for", "s"};
    foreach (string _pattern in TheStrings)
    {
        Point _P = TextBox2.GetPositionFromCharIndex(TextBox2.Text.IndexOf(_pattern));
        TextRenderer.DrawText(TextBox2.CreateGraphics(), _pattern, TextBox2.Font, _P,
                              TextBox2.ForeColor, Color.LightSkyBlue, _Flags);
    }
    TheStrings = new string []{"m", "more"};
    foreach (string _pattern in TheStrings)
    {
        Point _P = richTextBox1.GetPositionFromCharIndex(richTextBox1.Text.IndexOf(_pattern));
        TextRenderer.DrawText(richTextBox1.CreateGraphics(), _pattern, richTextBox1.Font, _P,
                              richTextBox1.ForeColor, Color.LightSteelBlue, _Flags);
    }
