    private void writeColor(string text, RichTextBox rtb, Color c, bool newLine = false) {
      if (newLine) rtb.AppendText(Environment.NewLine);
      rtb.SelectionBackColor = c;
      rtb.AppendText(text);
    }
