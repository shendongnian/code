    public event RoutedEventHandler Click
    {
        add { button.AddHandler(ButtonBase.ClickEvent, value); }
        remove { button.RemoveHandler(ButtonBase.ClickEvent, value); }
    }
