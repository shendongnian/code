    public async Task MyMethodAsync()
    {
        Task<int> runTask = RunOperationAsync();
    
        int result = await longRunningTask;
        Console.WriteLine(result);
    }
    
    public async Task<int> RunOperationAsync()
    {
        await Task.Delay(1000); //1 seconds delay
        return 1;
    }
