    public string FromValue
    {
        get
        {
            return _FromValue;
        }
        set
        {
            _FromValue = value;
            _ToValue = FromValue + "x";
            OnPropertyChanged("FromValue");
            OnPropertyChanged("ToValue");
        }
    }
    private string _ToValue { get; set; }
    public string ToValue
    {
        get
        {
            return _ToValue;
        }
        set
        {
            _ToValue = value;
            _FromValue = ToValue + "y";
            OnPropertyChanged("ToValue");
            OnPropertyChanged("FromValue");
        }
    }
