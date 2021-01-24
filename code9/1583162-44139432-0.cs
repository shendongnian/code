    public string UserName
    {
        get { return _username; }
        set {
            if (_username != value)
            {
                RaisePropertyChanged("UserName");
            }
        }
    }
