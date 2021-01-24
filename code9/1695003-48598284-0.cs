    public static readonly RoutedEvent SearchEvent = EventManager.RegisterRoutedEvent(
        "Search", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AdvComboBox));
    
    // Provide CLR accessors for the event
    public event RoutedEventHandler Search
    {
            add { AddHandler(SearchEvent , value); } 
            remove { RemoveHandler(SearchEvent, value); }
    }
