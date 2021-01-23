    public string DependentFoo
    {
        get { return _foo; }
        set
        {    
            if (string.Equals(_foo, value)) return;
            _foo= value;
            //if some condition:
            DependentBar = "";
            OnPropertyChanged();
        }
    }
    public string DependentBar
    {
        get { return _bar; }
        set
        {    
            if (string.Equals(_bar, value)) return;
            _bar = value;
            //if some condition:
            DependentFoo = "";
            OnPropertyChanged();
        }
    }
