    public int Age
    {
        get { return _age; }
        set
        {
            if ((value > 1) && (value <= 100))
                _age = value;
            RaisePropertyChanged("Age");
        }
    }
