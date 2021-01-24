    private string _Name; //<-- not initialized, Null
    public string Name
    {
        get { return _Name; }
        set { SetProperty(ref _Name, value); }
    }
