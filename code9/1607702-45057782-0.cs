    public string Password
    { 
        get { return _user.Password; }
        set { return _user.Password = value; OnNotifyPropertyChanged(); }
    }
