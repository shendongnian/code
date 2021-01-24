    [ThreadStatic]
    private static object _data;
    protected static object Data
    {
        get
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Items[DataKey] as object;
            else
                return _data;
        }
        set
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items[DataKey] = value;
            else
                _data = value;
        }
    }
