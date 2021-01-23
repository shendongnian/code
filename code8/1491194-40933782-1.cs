    private int _index;
    public int Index
    {
        get
        {
             return _index;
        }
        set
        {
            _index = value;
            OnIndexChanged(value);
        }
    }
