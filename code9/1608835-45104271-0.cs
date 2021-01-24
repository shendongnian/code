    public int ActualReading
    {
        get { return _ActualReading;}
        set {    
            // only update if new value is bigger than old value  
            if (value > _ActualReading) {      
              _ActualReading = value;
              RaisePropertyChanged("ActualReading");
            }
        }
    }
