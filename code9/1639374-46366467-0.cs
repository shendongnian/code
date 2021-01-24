    public string PropertyA
    {
        get { return propertyA; }
        set
        {
            myPropertyA = value;
            RaisePropertyChanged(nameof(PropertyA));  
            RaisePropertyChanged(nameof(IsPropertyAValid));
            ...
        }
    }
