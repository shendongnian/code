    public event RoutedEventHandler MyEvent
    {
        add { combo.AddHandler(PreviewKeyDownEvent, value); }
        remove { combo.RemoveHandler(PreviewKeyDownEvent, value); }
    }
