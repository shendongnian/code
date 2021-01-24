    int BatchSize = 1000;
    IEnumerable<string> Tail = DeviceIds;
    while (Tail.Count() > 0)
    {
        var Head = Tail.Take(BatchSize);
        // process Head
        Tail = Tail.Skip(BatchSize);
    }
