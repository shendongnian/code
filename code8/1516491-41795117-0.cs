    KVP[] temperatures = {
        new KVP("Day 1", 22),
        new KVP("Day 2", 23),
        new KVP("Day 2", 25),
        new KVP("Day 2", 26),
        new KVP("Day 2", 18),
        new KVP("Day 2", 16),
        new KVP("Day 2", 17),
        new KVP("Day 2", 27),
        new KVP("Day 2", 23),
        new KVP("Day 2", 24)
    };
    ILookup<int, string> lookup = temperatures.ToLookup(p => p.Value, p => p.Key);
    //string example1 = string.Join(", ", lookup[23]);              // "Day 2, Day 2"
    //string example2 = string.Join(", ", lookup[23].Distinct());   // "Day 2"
    int min = lookup.Min(p => p.Key);                               // 16
    int max = lookup.Max(p => p.Key);                               // 27
    //var avg = lookup.Average(p => p.Key);                         // 22.0 (incorrect)
    var avg = temperatures.Average(p => p.Value);                   // 22.1
    var minDays = string.Join(", ", lookup[min].Distinct());        // "Day 2"
    var maxDays = string.Join(", ", lookup[max].Distinct());        // "Day 2"
