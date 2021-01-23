    private static readonly object _lock = new object();
    public static object GetData(string key, object initialValue)
    {
        lock(_lock)
        {
           object val = CallContext.LogicalGetData(key);
           if (val == null)
               CallContext.LogicalSetData(key, initialValue);
           return val;
        }
    }
