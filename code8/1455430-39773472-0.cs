    // Find duplicates.
    var duplicates = statuses
        .Zip(statuses.Skip(1), (s1, s2) => Tuple.Create(s1, s2))
        .Where(pair => 
            pair.Item1.NewStatus == pair.Item2.NewStatus && 
            pair.Item1.OldStatus == pair.Item2.OldStatus)
        .Select(pair => pair.Item2);
    // Remove the duplicates from the original collection of the status changes.
    statuses.RemoveAll(s => duplicates.Contains(s));
