    private int _i = 0;
    public int i
    {
        get { return _i; }
        set
        {
            if (_i == value) { return; }
            _i = value;
            callback(value);
        }
    }
