    private static void Main()
    {
        var items = Enumerable.Range(-1000, 2001).ToList();
        var combinations = new List<List<int>>();
        var withIfCount = new List<long>();
        var withoutIfCount = new List<long>();
        var sw = new Stopwatch();
        // Both test are run 100 times
        for (int count = 0; count < 100; count++)
        {
            sw.Restart();
            for (int outer = 0; outer < items.Count; outer++)
            {
                for (int inner = 0; inner < items.Count; inner++)
                {
                    if (outer == 0 && inner == 0) continue;
                    combinations.Add(new List<int> {outer, inner});
                }
            }
            sw.Stop();
            withIfCount.Add(sw.ElapsedMilliseconds);
            combinations.Clear();
            sw.Restart();
            for (int outer = 0; outer < items.Count; outer++)
            {
                for (int inner = 0; inner < items.Count; inner++)
                {
                    combinations.Add(new List<int> {outer, inner});
                }
            }
            sw.Stop();
            withoutIfCount.Add(sw.ElapsedMilliseconds);
            combinations.Clear();
        }
        // Display averages
        Console.WriteLine("Average time with 'if': " + withIfCount.Average());
        Console.WriteLine("Average time without 'if': " + withoutIfCount.Average());
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
