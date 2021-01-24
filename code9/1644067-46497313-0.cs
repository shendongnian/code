    private string _test;
    public string Test
    {
        get { return _test; }
        set
        {
            if (value != _test) on_prop_changed();
            _test = value;
        }
    }
