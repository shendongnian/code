    public static async Task RepeatActionEveryInterval(Action action, TimeSpan interval, CancellationToken cancelToken)
    {
        while (true)
        {
            action();
            Task task = Task.Delay(interval, cancelToken);
            try
            {
                await task;
            }
            catch (TaskCanceledException)
            {
                return;
            }
        }
    }
    static void Main(string[] args)
    {
        CancellationTokenSource cancelToken = new CancellationTokenSource(TimeSpan.FromSeconds(50));
        Console.WriteLine("Start");
        RepeatActionEveryInterval(() => Console.WriteLine("Repeating Code"), TimeSpan.FromSeconds(5), cancelToken.Token).Wait();
        Console.WriteLine("End");
        Console.Read();
    }
