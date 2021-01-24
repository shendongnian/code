    var filteredResults = results
        .Where(r => r.Count == NoDisplay)
        .Take(3);
    foreach (var result in filteredResults)
    {
        foreach (decimal value in result)
        {
            Console.Write("{0}\t", value);
        }
        Console.WriteLine();
    }
