    public static void myLongTask(int time, CancellationToken token)
    {
        var sw = Stopwatch.StartNew();
        Console.WriteLine("Task started");
        while (true)
        { 
          token.ThrowIfCancellationRequested();
        }
        Console.WriteLine("Task ended");
    }
