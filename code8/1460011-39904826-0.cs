    var groups = new[] { "A", "B", "C", "D" };
    var range = Enumerable.Range(0, 1000).ToArray();
    var groupSize = range.Length / groups.Length;
    var split = range.GroupBy(c => Math.Min(c / groupSize, groups.Length - 1)).ToDictionary(c => groups[c.Key], c => c.ToArray());
    Console.WriteLine(String.Join(" ", ranges["A"]));   
