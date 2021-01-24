    string[] TheStrings = {"for", "s"};
    foreach (string pattern in TheStrings)
    {
        Point p = TextBox2.GetPositionFromCharIndex(TextBox2.Text.IndexOf(pattern));
        TextRenderer.DrawText(TextBox2.CreateGraphics(), pattern, TextBox2.Font, p,
                              TextBox2.ForeColor, Color.LightSkyBlue, flags);
    }
    TheStrings = new string []{"m", "more"};
    foreach (string pattern in TheStrings)
    {
        Point p = richTextBox1.GetPositionFromCharIndex(richTextBox1.Text.IndexOf(pattern));
        using (Graphics g = richTextBox1.CreateGraphics())
            TextRenderer.DrawText(g, pattern, richTextBox1.Font, p,
                                  richTextBox1.ForeColor, Color.LightSteelBlue, flags);
    }
