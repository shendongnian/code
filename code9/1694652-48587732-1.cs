    void Click(object sender, EventArgs e, int extraInfo)
    {
        var btn= (Button)sender;
        .....
    }
    
    button1.Click+=(s, e) => Click(s, e, 1);
    button2.Click+=(s, e) => Click(s, e, 2);
    button3.Click+=(s, e) => Click(s, e, 3);
    button4.Click+=(s, e) => Click(s, e, 4);
