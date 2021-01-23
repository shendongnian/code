    public string Example
    {
        get { return _example; }
        set
        {
            _example= value;
            OnPropertyChanged();                
        }
    }
