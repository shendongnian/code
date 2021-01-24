    private string _Name; //<-- not initialize, Null
    public string Name
    {
        get { return _Name; }
        set { SetProperty(ref _Name, value); }
    }
