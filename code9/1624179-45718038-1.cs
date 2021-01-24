    public string X
    {
        get
        {
            return _X;
        }
        set
        {
            _X = value;
            OnPropertyChanged("X");
            OnPropertyChanged("SUM");
        }
    }
