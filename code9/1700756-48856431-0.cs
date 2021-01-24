    private bool myIsVisible = true;
    public bool MyIsVisible
    { 
      get => myIsVisible; 
      set
      {
        myIsVisible = value; 
        OnPropertyChanged(nameof(MyIsVisible));
      }
    }
