    var counters = new ConcurrentDictionary<string, int>();
    var threads = Enumerable.Range(0, 5).Select(i => new Thread(() =>
    {
        var key = $"Thread {i}";
        for (var j = 0; j < 10; ++j)
        {
            var counter = j;
            counters.AddOrUpdate(key, counter, (k, v) => counter);
            Thread.Sleep(200);
        }
    })).ToList();
    threads.ForEach(t => t.Start());
    while (threads.Any(t => t.IsAlive))
    {
        int line = 0;
        foreach (var counter in counters)
        {
            Console.SetCursorPosition(1, line++);
            Console.WriteLine($"{counter.Key} - {counter.Value}");
            Thread.Sleep(50);
        }
    }
