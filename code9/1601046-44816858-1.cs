    var data = new List<double>() { 32.00, 95.00, 60.00, 14.00, 62.00 };
    // As Tuple<double, double>[] array:
    var results = data.OrderByDescending(x => x).GroupBy2().ToArray(); 
    // Iterate through IEnumerable<Tuple<double, double>>:
    foreach (var pair in data.OrderByDescending(x => x).GroupBy2())
    {
        Console.WriteLine($"{pair.Item1} {pair.Item2}");
    }
