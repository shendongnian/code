    var groups = new[] { "A", "B", "C", "D" };
    // range size and group size is configurable, should work with any range.
    var range = Enumerable.Range(0, 1000).ToArray();
    var groupSize = range.Length / groups.Length;
    // here we split range in groups. If range size is not exactly divisable to groups size - all left elements go to the last group
    // then we form a dictionary with labels as keys and array of numbers as values
    var split = range.GroupBy(c => Math.Min(c / groupSize, groups.Length - 1)).ToDictionary(c => groups[c.Key], c => c.ToArray());
    Console.WriteLine(String.Join(" ", ranges["A"]));   
