    for(int i = 0; i < 5; ++i)
    {
        var button = new Button();
        button.Tag = i; 
        button.Click += Button_Click();
    }
