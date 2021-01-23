    DateTime[] last7Days = Enumerable.Range(0, 7)
        .Select(i => DateTime.Now.Date.AddDays(-i))
        .ToArray();
    foreach (var day in last7Days)
        Console.WriteLine($"{day:yyyy-MM-dd}"); // Any manipulations with days go here
