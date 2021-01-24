    private static void Main()
    {
        var progress = new Progress(50)
        {
            ReportIncrement = 10,
            Increment = Progress.IncrementType.Percent
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
