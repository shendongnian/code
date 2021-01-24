    var groupedLogs = commonlog2
        .GroupBy(c => c.Break, c => TimeSpan.Parse(c.Length))
        // group logs by Break, and get the TimeSpan representation of Length
        // for each entry of the group
        .ToDictionary(g => g.Key, g => g.Aggregate(TimeSpan.Zero, (s, c) => s + c));
        // create a dictionary and aggregate each log group into sums of TimeSpans
