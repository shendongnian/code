    // Make word counts for l1 and l2
    var c1 = l1.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
    var c2 = l2.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
    // Make a count of the difference between the two
    var diff = new Dictionary<string,int>();
    foreach (var p in c1) {
        int sub;
        if (!c2.TryGetValue(p.Key, out sub)) {
            sub = 0;
        }
        diff[p.Key] = p.Value - sub;
    }
    // Reconstruct the result from counts
    var res = diff.SelectMany(p => Enumerable.Repeat(p.Key, p.Value)).ToList();
