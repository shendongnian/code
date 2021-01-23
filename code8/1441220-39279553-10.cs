    public Models.EventInfo EventInfo
    {
        get { return _eventInfo; }
        set
        {
            _eventInfo = value;
            OnPropertyChanged();
        }
    }
