    private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        int CurrentPosition = richTextBox1.SelectionStart;
        if (e.KeyChar == (char)Keys.Space && CurrentPosition > 0 && richTextBox1.Text.Length > 1)
        {
            int LastSpacePos = richTextBox1.Text.LastIndexOf((char)Keys.Space, CurrentPosition - 1);
            LastSpacePos = LastSpacePos > -1 ? LastSpacePos + 1 : 0;
            string LastWord = richTextBox1.Text.Substring(LastSpacePos, CurrentPosition - (LastSpacePos));
            ColoredWord result = ColoredWords.FirstOrDefault(s => s.Word == LastWord.ToUpper());
            richTextBox1.Select(LastSpacePos, CurrentPosition - LastSpacePos);
            if (result != null)
            {
                if (richTextBox1.SelectionColor != result.WordColor)
                    richTextBox1.SelectionColor = result.WordColor;
            }
            else
            {
                if (richTextBox1.SelectionColor != richTextBox1.ForeColor)
                    richTextBox1.SelectionColor = richTextBox1.ForeColor;
            }
            richTextBox1.SelectionStart = CurrentPosition;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
        }
    }
