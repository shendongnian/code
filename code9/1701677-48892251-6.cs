    /// <summary>
    ///     Declaration of the routed event reporting the left mouse button was pressed
    /// </summary>
    public static readonly RoutedEvent PreviewMouseLeftButtonDownEvent = 
        EventManager.RegisterRoutedEvent("PreviewMouseLeftButtonDown", 
                                         RoutingStrategy.Direct,
                                         typeof(MouseButtonEventHandler),
                                         _typeofThis);
