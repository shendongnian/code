    public EventViewModel(System.Collections.Specialized.NotifyCollectionChangedEventHandler changed)
    {
        ...
        Events = new ObservableCollection<Event>();
        Events.CollectionChanged += changed;
        ...
    }
