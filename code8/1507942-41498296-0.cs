    button1.Click += button_Click;
    button2.Click += button_Click;
    button3.Click += button_Click;
    ...
    private void button_Click(object sender, EventArgs e)
    {
        string text = (sender as Button).Text;
        
        items_Add(text); //assuming this is your common method
    }
