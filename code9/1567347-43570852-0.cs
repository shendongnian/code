    public long MyConfig1
    {
        get => GetConfig(Helpers.GetCallerName());
        set => SetConfig(Helpers.GetCallerName(), value);
    }
