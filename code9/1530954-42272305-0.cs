    private double _a;
    public double A
    {
        get { return _a; }
        set { _a = value; NotifyPropertyChanged(); NotifyPropertyChanged("D"); 
        hasAorBChanged = true;}
    }
    private double _b;
    public double B
    {
        get { return _b; }
        set { _b = value; NotifyPropertyChanged(); NotifyPropertyChanged("D"); 
        hasAorBChanged = true;}
    }
