    static void PerformAction(string name, int n, Action action)
    {
        // Warm up
        action();
        List<double> times = new List<double>();
        for (int i = 0; i < n; i++)
        {
            var sw = Stopwatch.StartNew();
            action();
            times.Add(sw.Elapsed.TotalMilliseconds);
        }
        Console.WriteLine("{0}: MIN: {1}, AVG: {2}, MAX: {3}", name, times.Min(), times.Average(), times.Max());
    }
