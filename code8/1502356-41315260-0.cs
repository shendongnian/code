    private void button1_Click(object sender, EventArgs e)
    {
        ToolTip myToolTip = new ToolTip();
        string test = "This is a test string.";
        int textWidth = TextRenderer.MeasureText(test, SystemFonts.CaptionFont, textBox1.Size, TextFormatFlags.LeftAndRightPadding).Width;
        textWidth += 6;
        int toolTipTextPosition_X = textBox1.Size.Width - textWidth;
        myToolTip.Show(test, textBox1, toolTipTextPosition_X, textBox1.Size.Height);
    }
