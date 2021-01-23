    public Dictionary<string, string> MyDict
    {
        get { return _MyDict; }
        set 
        {
            _MyDict = value;
            NotifyPropertyChanged("MyDict");
        }         
    }
