    static void Main()
    {
        var ra = new RecordA { Speed = 5 };
        var rb = new RecordB { Size = 10 };
        var recordList = new List<IRecord> { ra, rb };
        Console.WriteLine($"record A Speed before: {ra.Speed}");
        Console.WriteLine($"record B Size before: {rb.Size}");
        CallingMethod(recordList);
        Console.WriteLine($"record A Speed after: {ra.Speed}");
        Console.WriteLine($"record B Size after: {rb.Size}");
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
