    void MyMethod(Dispatcher uiDispatcher)
    {
    ...
    
        uiDispatcher.Invoke(() =>
                    {
        button1.Enabled = true;
        button2.Enabled = true;
        ...
                    });
    }
