    static void TestValueTuple(int n = 10000000)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var tupleDictionary = new Dictionary<(string, string, int), string>();
        for (var i = 0; i < n; i++)
        {
            tupleDictionary.Add((i.ToString(), i.ToString(), i), i.ToString());
        }
        stopwatch.Stop();
        Console.WriteLine($"initialization: {stopwatch.Elapsed}");
        stopwatch.Restart();
        for (var i = 0; i < n; i++)
        {
            var s = tupleDictionary[(i.ToString(), i.ToString(), i)];
        }
        stopwatch.Stop();
        Console.WriteLine($"Retrieving: {stopwatch.Elapsed}");
    }
