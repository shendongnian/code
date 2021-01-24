    private string _Name = string.Empty; //<-- need to be empty or "" string
    public string Name
    {
        get { return _Name; }
        set { SetProperty(ref _Name, value); }
    }
