    var groups = new[] { 0, 0, 1, 1, 0, 0 }.GroupConsecutive();
    var maxGroupped = groups.GroupBy(i => i.First()).Select(i => new
    {
           i.Key,
           Count = i.Max(j => j.Count())
    });
    foreach (var g in maxGroupped)
           Console.WriteLine(g.Count + " times " + g.Key);
