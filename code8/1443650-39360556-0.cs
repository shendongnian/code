    Dictionary<string, double> results = new Dictionary<string, double>();
    
    // Add your runners.
    results.Add(Runner1Name, Runner1Time);
    results.Add(Runner2Name , Runner2Time);
    results.Add(Runner3Name , Runner2Time);
    var bestTime = results.Max(item => item.Value);
    var worstTime = results.Min(item => item.Value);
    foreach (var item in results)
    {
        if (item.Value == bestTime)
        {
            Console.WriteLine($"First place {item.Key}");
            continue;
        }
        if (item.Value == worstTime)
        {
            Console.WriteLine($"Third place {item.Key}");
            continue;
        }
        Console.WriteLine($"Second place {item.Key}");
    }
