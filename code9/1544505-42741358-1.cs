    var groups = planes.GroupBy(p => p.Model);
    foreach (var group in groups)
    {
        Console.WriteLine("1. Model: {0}", group.Key);
        Console.WriteLine("2. Total Seats: {0}", group.Sum(p => p.Seats));
        Console.WriteLine("3. Attendants: {0}", group.Sum(p => p.Attendants));
    }
