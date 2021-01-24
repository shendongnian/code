    private static void Main()
    {
        var numDates = 1000000;
        var dates = new List<DateTime>();
        // initialize list with random dates
        var rnd = new Random();
        for (int i = 0; i < numDates; i++)
        {
            var day = rnd.Next(1, 29);
            var month = rnd.Next(1, 13);
            var year = rnd.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year + 1);
            dates.Add(new DateTime(year, month, day));
        }
        // Sort the list descending
        dates = dates.OrderByDescending(d => d).ToList();
        // find the two neighbors with the greatest distance
        double maxDays = 0;
        var sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < dates.Count - 1; i++)
        {
            var diff = (dates[i] - dates[i + 1]).TotalDays;
            if (diff > maxDays) maxDays = diff;
        }
        sw.Stop();
            
        // Display results
        Console.WriteLine($"The greatest difference was {maxDays} days.");
        Console.WriteLine($"The comparison of {dates.Count} items took {sw.ElapsedMilliseconds} milliseconds");
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
