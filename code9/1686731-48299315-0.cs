    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
            OnPropertyChanged("Name");
            OnPropertyChanged("NameIndex");
        }
    }
