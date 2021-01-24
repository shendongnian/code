    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.AppendText(text);
            box.SelectionStart = box.TextLength - text.Length;
            box.SelectionLength = text.Length;
            box.SelectionColor = color;
            box.SelectionStart = box.TextLength;
            box.SelectionColor = box.ForeColor;
        }
    }
