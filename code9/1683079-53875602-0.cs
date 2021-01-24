    public Task DoWorkAsync()
    {
        using (var service = new Service())
        {
            var arg1 = ComputeArg();
            var arg2 = ComputeArg();
            // NOT SAFE - service will be disposed
            // There is a high-probability that this idiom results 
            // in an ObjectDisposedException
            return service.AwaitableMethodAsync(arg1, arg2);
        }
    }
    
    public async Task DoWork2Async()
    {
        using (var service = new Service())
        {
            var arg1 = ComputeArg();
            var arg2 = ComputeArg();
            // This is fine, service is disposed of last
            await service.AwaitableMethodAsync(arg1, arg2);
        }
    }
