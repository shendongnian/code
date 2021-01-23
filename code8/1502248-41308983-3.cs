    var duplicates =
        OrigValues
            .Select((value, index) => new
                {
                    Coordinate = index,
                    Value = value
                })
            .GroupBy(tuple => tuple.Value)
            .Where(group => group.Count() > 1)
            .ToList();
    foreach (var group in duplicates)
    {
        Console.Write($"{group.Key} appears in");
        foreach (var tuple in group)
            Console.Write($"{tuple.Coordinate}");
        Console.WriteLine();
    }
