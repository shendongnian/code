    public bool ShowRock
    {
        get { return _showRock; }
        set
        {
            _showRock = value;
            OnPropertyChanged("ShowRock");
        }
    }
