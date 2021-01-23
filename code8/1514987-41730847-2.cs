    private DateTime _dt;
    public int Days
    {
        get { return _dt.Day; }
        set { _dt = new DateTime(_dt.Year, _dt.Month, value, _dt.Hour, _dt.Minute, _dt.Second, _dt.Millisecond); }
    }
        
    public int Hours
    {
        get { return _dt.Hour; }
        set { _dt = new DateTime(_dt.Year, _dt.Month, _dt.Day, value, _dt.Minute, _dt.Second, _dt.Millisecond); }
    }
