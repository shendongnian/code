    StackPanel myPanel = new StackPanel
    {
        MinWidth = 150,
        MinHeight = 150,
        AllowDrop = true
    };
    myPanel.DragOver += panel_DragOver;
    myPanel.Drop += panel_Drop;
    MainStack.Children.Add(myPanel);
