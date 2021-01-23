    var duplicates =
        OrigValues
            .Select((value, index) => new
                {
                    Row = index / 9,
                    Column = index % 9,
                    Value = value
                })
            .GroupBy(tuple => tuple.Value)
            .Where(group => group.Count() > 1)
            .ToList();
    foreach (var group in duplicates)
    {
        IEnumerable<string> coordinates = 
            group.Select(tuple => $"({tuple.Row}, {tuple.Column})");
        string report = string.Join(", ", coordinates);
        Console.WriteLine($"{group.Key} appears in {report}");
    }
