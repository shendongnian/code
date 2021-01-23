    public string Foo
    {
        get { return _foo; }
        set
        {    
            if (string.Equals(_foo, value)) return;
            _foo= value;
            OnPropertyChanged();
        }
    }
