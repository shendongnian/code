    textBox1.TextChanged += new TextChangedEventHandler(textBox1_TextChanged);
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        Regex regex = new Regex(@"[^0-9^+^\-^\/^\*^\(^\)]");
        MatchCollection matches = regex.Matches(textBox1.Text);
        if (matches.Count > 0) {
           //tell the user
        }
    }
    
    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string yourWord = "mouse";
            if (textBox1_Text.Text.Contains(yourWord))
            {
                textBox1_Text.Text.Replace(yourWord, "");
            }
        }
     
