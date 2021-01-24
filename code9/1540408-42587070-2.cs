    private double physValue;        
    public double PhysValue { 
      get { return physValue; } 
      set {
         physValue = value;
         RaisePropertyChanged();
      }
    }
