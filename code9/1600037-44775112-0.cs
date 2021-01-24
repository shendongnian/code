    var tupleList = items.Select(item => (item.A1, item.A2)).ToList();
    ...
    foreach (var item in tupleList)
    {
        Console.WriteLine(item.Item1);
        Console.WriteLine(item.Item2);
    }
