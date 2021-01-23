    public BaseClass myClassBase
    {
        get { return _myClassBase; }
        set
        {
            RaisePropertyChanging();
            _myClassBase = value;
            RaisePropertyChanged();
        }
    }
    private BaseClass _myClassBase;
