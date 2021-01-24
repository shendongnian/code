    var byDuration = times.GroupBy(t => t.Duration).ToDictionary(g => g.Key, g => g.ToList());
    var pairs = new List<Tuple<Timing,Timing>>();
    foreach (var t1 in times) {
        List<Timing> list;
        if (byDuration.TryGetValue(20-t1.Duration, out list)) {
            pairs.AddRange(list.Where(t2 => t1 != t2).Select(t2 => Tuple.Create(t1, t2)));
        }
    }
