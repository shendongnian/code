    private Meter _meterValue;
    public Meter _meter
    {
        get { return _meterValue; }
        set { _meterValue = value; RaisePropertyChanged(nameof(_meter)); }
    }
