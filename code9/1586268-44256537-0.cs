    public static void Main(string[] args)
    {
        var tokenSource = new CancellationTokenSource();
        Console.WriteLine("Press CTRL+C to cancel important work");
        Console.CancelKeyPress += (sender, eventArgs) => {
            eventArgs.Cancel = true;
            tokenSource.Cancel();
        };
        var task = Task.Run(() => foo(tokenSource.Token));
        task.Wait();
        WaitFor(action: "exit");
    }
    private static void foo(CancellationToken token)
    {
        const int Times = 10;
        for (var x = 0; x < Times && token.IsCancellationRequested == false; ++x) {
            Console.WriteLine("Important work");
            Task
                .Delay(200)
                .Wait();
        }
        Console.WriteLine($"Free resources: {token.IsCancellationRequested}");
    }
    public static void WaitFor(ConsoleKey consoleKey = ConsoleKey.Escape, string action = "continue")
    {
        Console.Write($"Press {consoleKey} to {action} ...");
        var consoleKeyInfo = default(ConsoleKeyInfo);
        do {
            consoleKeyInfo = Console.ReadKey(true);
        }
        while (Equals(consoleKeyInfo.Key, consoleKey) == false);
        Console.WriteLine();
    }
