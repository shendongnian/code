    private ClassA _classA;
    public ClassA classA
    {
        get
        {
            return _classA;
        }
        set
        {
            if (_classA != value)
            {
                _classA = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ClassA"));
                }
            }
        }
    }
