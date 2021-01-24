    private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
    {
        if (richTextBox1.SelectionColor.ToArgb() != richTextBox1.ForeColor.ToArgb())
        {
            try
            {
                int WordInit = richTextBox1.Text.LastIndexOf((char)32, richTextBox1.SelectionStart);
                WordInit = WordInit > -1 ? WordInit : 0;
                int WordEnd = richTextBox1.Text.IndexOf((char)32, richTextBox1.SelectionStart);
                string WordClicked = richTextBox1.Text.Substring(WordInit, WordEnd - WordInit) + Environment.NewLine;
                OnWordClicked(new WordsEventArgs(WordClicked));
            }
            catch (Exception)
            {
                //Handle a fast doublelick: RTB is a bit dumb.
                //Handle a word auto-selection that changes the `.SelectionStart` value
            }
        }
    }
