    public bool IsGazeActivated 
    {
     get { return _bIsGazeActivated; }
     set { if (value != bIsGazeActivated) RaiseOnPropertyChanged("IsGazeActivated"); }
    }
