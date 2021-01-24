    private string _name = string.Empty; 
    public string Name
    {
        get{ return _name;}
        set 
        {
            _name = value;
            RaisePropertyChanged("Name");
        }
    }
