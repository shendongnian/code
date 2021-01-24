    private static Task RunParallelThrottled()
    {
        var throtter = new ActionBlock<int>(i => CallSomeWebsite(),
            new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 20 });
        for (var i = 0; i < 300; i++)
        {
            throttler.Post(i);
        }
        throttler.Complete();
        return throttler.Completion;
    }
