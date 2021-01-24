    void Click(object sender, EventArgs e)
    {
        var btn= (Button)sender; // you can access properties which you might have set to identify which button it is 
        .....
    }
    
    button1.Click+=Click;
    button2.Click+=Click;
    button3.Click+=Click;
    button4.Click+=Click;
