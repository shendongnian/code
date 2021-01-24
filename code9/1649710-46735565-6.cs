    var converted = new List<Items<string>>(initial.Count);
    var sum = 0.0;
    foreach (var item in initial.Take(initial.Count - 1))
    {
        sum += item.Probability;
        converted.Add(new Items<string> {Probability = sum, Item = item.Item});
    }
    converted.Add(new Items<string> {Probability = 1.0, Item = initial.Last().Item});
