    public static Dictionary<string, IData> RegisterTheseInstances()
    {
        return new Dictionary<string, IData>()
        {
            { "customer", new Customer() },
            { "test",  new Test() }
        };
    }
