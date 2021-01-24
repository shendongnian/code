    public async Task MyMehod()
    {
        Task longRunningTaks = Task.Run(() => DoSomething());
        Stopwatch stopwatch = Stopwatch.StartNew();
        while (!longRunningTaks.IsCompleted)
        {
            Console.Write($"Elapsed time... {Math.Round( stopwatch.Elapsed.TotalSeconds,0)}" );
            await Task.Delay(1000);
        }
    }
    public async Task DoSomething()
    {
        await Task.Delay(3000);
    }
