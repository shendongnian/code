    private static void Main()
    {
        var progress = new Progress(50)
        {
            ReportIncrement = 10,
            IncrementType = Progress.Increment.Percent
        };
        Console.WriteLine("Starting");
        for (int i = 0; i < progress.Total; i++)
        {
            Console.Write('.');
            Thread.Sleep(100);
            progress.Completed++;
        }
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
