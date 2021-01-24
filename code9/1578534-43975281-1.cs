    #if FOO
    public Task DoFooAsync() => Task.FromResult(0);
    #else 
    public Task DoFooAsync()
    {
        //...
    }
    #endif
