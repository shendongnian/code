    public bool IsGazeActivated 
    {
     get { return _bIsGazeActivated; }
     set { if (value != _bIsGazeActivated) RaiseOnPropertyChanged("IsGazeActivated"); }
    }
