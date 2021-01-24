    Button[] buttons;
    foreach(var button in buttons)
    {
        button.Click += MyHandler;
    }
    
    // method1
    private void MyHandler(object sender, EventArgs e)
    {
        if(sender == buttons[0])
            // Do something...
        else if(sender == buttons[1])
            // do something else...
        else if(sender == buttons[2])
            // and so on...
    }
    // method2
    private void MyHandler(object sender, EventArgs e)
    {
        var button = (Button)sender;
        switch(button.Text)
        {
            case "+":
            case "1":
            case "2":
            // and so on...
        }
    }
