    static void Test3()
    {
        var cts = new CancellationTokenSource();
        var processingTask = Task.Factory.StartNew(() => GetStreamFromYoutubeDl(),cts.Token);
        var readingFromConsoleTask = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Press 'q' to exit.");
            while (true)
            {
                var read = Console.ReadKey(true);
                if (read.Key == ConsoleKey.Q)
                {
                    cts.Cancel();
                    return;
                }
            }
        });
    
        Task.WaitAny(processingTask, readingFromConsoleTask);
    }
