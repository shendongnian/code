    public void testb<T>(Func<T, T> action, T testValue)
    {
        action(testValue);        
    }
    public void testall()
    {
        testa(tc =>
        {
            return tc;
        });
        testb<string>(tc =>
        {
            return tc;
        }, "where??");
    }
