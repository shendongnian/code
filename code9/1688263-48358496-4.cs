    private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
    {
        if (richTextBox1.SelectionColor.ToArgb() != richTextBox1.ForeColor.ToArgb())
        {
            try
            {
                int _WordInit = richTextBox1.Text.LastIndexOf((char)32, richTextBox1.SelectionStart);
                int _WordEnd = richTextBox1.Text.IndexOf((char)32, richTextBox1.SelectionStart);
                string _WordClicked = richTextBox1.Text
                                      .Substring(_WordInit, _WordEnd - _WordInit) + Environment.NewLine;
                OnWordClicked(new WordsEventArgs(_WordClicked));
            }
            catch (Exception)
            {
                //Handle a fast doublelick: RTB is a bit dumb.
                //Handle a word auto-selection that changes the `.SelectionStart` value
            }
        }
    }
