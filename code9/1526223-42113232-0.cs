    private static ConcurrentQueue<string> _data = new   ConcurrentQueue<string>(new [] { "a", "b", "c", "d" });
    static void Main(string[] args)
    {
        var observable = Observable
            .Interval(TimeSpan.FromSeconds(2))
            .Select(Transform)
            .TakeWhile(x => x != null);
        Console.WriteLine("Wait for the observable to complete.");
        observable
            .Do(x => Console.WriteLine("Event raised for {0}", x))
            .Wait();
        Console.WriteLine("Press any key to exit. . .");
        Console.ReadKey();
    }
    private static string Transform(long x)
    {
        string result;
        _data.TryDequeue(out result);
        Console.WriteLine("Transform invoked [x: {0}, Result: {1}]", x, result ?? "NULL");
        return result;
    }
