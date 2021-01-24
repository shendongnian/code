    private string _name;
    public string Name
    {
        get {return $"My Name is {_name}";}
        set 
        {
            _name = value;
            //OnPropertyChanged("Name");
        }
    }
