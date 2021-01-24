    public string path
    {
        set ///This is never called
        {
            _path = value;
            RaisePropertyChanged("path");
        }
    }
