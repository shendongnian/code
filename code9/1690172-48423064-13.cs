    public void Test<T>(ITest<T> x)
    {
        var getter = GetGenericPropertyDelegate<int>("Item");
    
        Assert(getter(x).Equals(x.Item));
    }
