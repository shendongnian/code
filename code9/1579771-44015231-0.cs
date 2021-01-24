    private int _i = 0;
    public int i
    {
        get { return _i; }
        set
        {
            _i = value;
            callback(value);
        }
    }
