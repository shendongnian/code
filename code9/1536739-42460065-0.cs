    private void adition()
    {
    
        int a = 0;
        int b = 0;
        int c = 0;
    
        Int32.TryParse(textbox1.Text, out a);
        Int32.TryParse(textbox2.Text, out b);
        Int32.TryParse(textbox3.Text, out c);
        resultLabel.Text = (a + b + c).ToString();
    }
