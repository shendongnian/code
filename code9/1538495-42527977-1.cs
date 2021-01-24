    WhenAllWithTokenResult<string> result = 
        await WhenAllWithToken(
                        new[]
                        {
                            Tuple.Create(_someService.Method1(), "Method1"),
                            Tuple.Create(_someService.Method2(), "Method2"),
                            Tuple.Create(_someService.Method3(), "Method3"),
                            Tuple.Create(_someService.Method4(), "Method4")
                        });
    foreach (var item in result.SuccessfulTasks)
    {
        Console.WriteLine("Successful: {0}", item.Item2);
    }
    foreach (var item in result.FailedTasks)
    {
        Console.WriteLine("Failed: {0}", item.Item2);
    }
    foreach (var item in result.CancelledTasks)
    {
        Console.WriteLine("Cancelled: {0}", item.Item2);
    }
