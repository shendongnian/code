    static void RunTest(string name, Func<byte[], byte[], bool> action, byte[] a, byte[] b)
    {
        TimeSpan total = TimeSpan.Zero;
        for (var i = 0; i < 5; i++)
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            action(a, b);
            _stopwatch.Stop();
            total += _stopwatch.Elapsed;
        }
        Console.WriteLine(name + ": " + (total.TotalMilliseconds / 5));
    }
