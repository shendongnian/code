    public static class Extenstions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            // Append the text, but color only the numbers
            foreach (char character in text)
            {
                box.AppendText(character.ToString());
                if (!char.IsNumber(character)) continue;
                box.SelectionStart = box.TextLength - 1;
                box.SelectionLength = 1;
                box.SelectionColor = Color.Red;
                box.SelectionStart = box.TextLength;
                box.SelectionColor = box.ForeColor;
            }
        }
    }
