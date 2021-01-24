    // using the new C# 7 tuple syntax!
    foreach(var group in Journeys.GroupBy(x => (x.To, x.From))) {
        Console.WriteLine($"People traveling from {group.Key.Item1} to {group.Key.Item2}:");
        foreach (var subgroup in group.GroupBy(x => x.Gender)) {
            Console.WriteLine($"{subgroup.Key}: {subgroup.Count()} people");
        }
    }
