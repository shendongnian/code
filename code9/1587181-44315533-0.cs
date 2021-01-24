    public void Deadlock()
    {
        DoSomething.Wait();
    }
    
    public Task DoSomething()
    {
        // Some stuff
        await DoSomethingElse();
        // More stuff
    }
