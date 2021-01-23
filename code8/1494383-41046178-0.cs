    public double CurrentVehLong
    {
        get { return VehLong[CurrentIteration];; }
        set 
        { 
            VehLong[CurrentIteration] = value; 
            OnPropertyChanged("CurrentVehLong"); 
        }
    }
