    public static readonly RoutedEvent ClickEvent =
        ButtonBase.ClickEvent.AddOwner(typeof(ButtonLarge));
    public event RoutedEventHandler Click
    {
        add { button.AddHandler(ClickEvent, value); }
        remove { button.RemoveHandler(ClickEvent, value); }
    }
