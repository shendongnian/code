    public Visibility PauseButtonVisibility
    {
        get
        {
            return _pauseButtonVisiblity;
        }
        set
        {
            _pauseButtonVisiblity = value;
            NotifyPropertyChanged("PauseButtonVisibility"); // <---- This is what you want.
        }
    }
