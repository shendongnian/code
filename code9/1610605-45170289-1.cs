    static void Main()
    {
        var set = new[] { 5, 1, 8, 10, 50, 4, 37, 8, 1 };
        var batches = set.Batches(2);
        var result = string.Join("\r\n", 
                                 batches.Select(batch => string.Join(",", batch)));
        Console.WriteLine(result);
    }
