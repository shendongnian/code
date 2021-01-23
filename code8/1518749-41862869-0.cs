    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
    
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        public static void UpdateText(this RichTextBox box, string find, string replace, Color? color)
        {
            box.SelectionStart = box.Find(find, RichTextBoxFinds.Reverse);
            box.SelectionLength = find.Length;
            box.SelectionColor = color ?? box.SelectionColor;
            box.SelectedText = replace;
        }
    }
