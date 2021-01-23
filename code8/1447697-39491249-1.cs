    public void ExecuteTimedFunction(Action action, string name)
    {
        Console.Write(name);
        var watch = Stopwatch.StartNew();
        action();
        watch.Stop();
        Console.WriteLine("... finished in: {0} s", watch.ElapsedMilliseconds/1000d);
    }
