    private bool isGazeActivated;
    public bool IsGazeActivated
    {
     get{ return isGazeActivated;}
     set
     {
      isGazeActivated = value;
      NotifyPropertyChanged("IsGazeActivated"); or RaiseOnPropertyChanged("IsGazeActivated");
     }
    }
