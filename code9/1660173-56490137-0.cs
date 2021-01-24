    static async Task Main(string[] args)
    {
    
        Task task = test(); // Will throw exception here
        await task;
    
        Task taskAsync = testWithAsync();
        await taskAsync; // Will throw exception here
    }
    
    static Task test()
    {
        throw new Exception();
        return Task.CompletedTask; //Unreachable, but left in for the example
    }
    
    static async Task testWithAsync()
    {
        throw new Exception();
    }
