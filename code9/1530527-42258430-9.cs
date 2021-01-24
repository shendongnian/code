    static void Main()
    {
        var rnd = new Random();
        var set = Enumerable.Range(0, 10000000).Select(i => rnd.NextDouble() * 100).ToArray();
        var s = 50;
        var e = 1000000;
        var sw = new Stopwatch();
        var r = new[] { new List<long>(), new List<long>(), new List<long>() };
        for (var i = 0; i < 1000; i++)
        {
            sw.Restart();
            FixMaxFixed(set, s, e);
            sw.Stop();
            r[0].Add(sw.ElapsedTicks);
            sw.Restart();
            FindMax(set, s, e);
            sw.Stop();
            r[1].Add(sw.ElapsedTicks);
            sw.Restart();
            FindMaxFastest(set, s, e);
            sw.Stop();
            r[2].Add(sw.ElapsedTicks);
        }
        //5721.785 6098.866 5432.225
        Console.WriteLine(string.Join(" ", r.Select(i => i.Average())));
        Console.Read();
    }
