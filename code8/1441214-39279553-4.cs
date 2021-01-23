    private ObservableCollection<Models.EventInfo> _eventInfoItems = 
        new ObservableCollection<Models.EventInfo>();
    public ObservableCollection<Models.EventInfo> EventInfoItems
    {
        get { _eventInfoItems; }
        set
        {
            _eventInfoItems = value;
            OnPropertyChanged();
        }
    }
