    private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        int _CurrentPosition = richTextBox1.SelectionStart;
        if (e.KeyChar == (char)Keys.Space && richTextBox1.Text.Length > 1)
        {
            int _LastSpacePos = richTextBox1.Text.LastIndexOf((char)Keys.Space, _CurrentPosition - 1);
            _LastSpacePos = _LastSpacePos > -1 ? _LastSpacePos : 0;
            int _FirstLinePos = richTextBox1.GetFirstCharIndexOfCurrentLine();
            _LastSpacePos = _LastSpacePos <= _FirstLinePos ? _FirstLinePos : _LastSpacePos + 1;
            string _LastWord = richTextBox1.Text.Substring(_LastSpacePos, _CurrentPosition - _LastSpacePos);
            ColoredWord result = _ColoredWords.Find(s => s.Word == _LastWord.ToUpper());
            if (result != null)
            {
                richTextBox1.Select(_LastSpacePos, _CurrentPosition - _LastSpacePos);
                richTextBox1.SelectionColor = result.WordColor;
                richTextBox1.SelectionStart = _CurrentPosition;
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
            }
        }
    }
