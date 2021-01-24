    private void RebText_TextChanged(object sender, RoutedEventArgs e)
    {
        //Clear line numbers
        LineNumbers.Items.Clear();
        int i = 1;
    
        //Get all the thext
        ITextRange text = RebText.Document.GetRange(0, TextConstants.MaxUnitCount);
        string s = text.Text;
    
        if (s != "\r")
        {
            //Replace return char with some char that will be never used (I hope...)
            string[] tmp = s.Replace("\r", "§").Split('§');
            foreach (string st in tmp)
            {
                //String, adding new line
                if (st != "")
                {
                    LineNumbers.Items.Add(i++);
                }
                //No string, empty space
                else
                {
                    LineNumbers.Items.Add("");
                }                      
            }
        }
    }
