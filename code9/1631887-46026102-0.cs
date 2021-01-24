    public void Test<T>(T result)
    {
        var asBool = result as bool?;
        if (!asBool.HasValue || !asBool.Value)
        {
            // do whatever
        }
    }
