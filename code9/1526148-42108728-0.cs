    var masterlist = new List<Dictionary<DateTime, double>>();
    Dictionary<DateTime, List<double>> dtDoubles = new Dictionary<DateTime, List<double>>();
    foreach (var item in masterlist)
    {
        foreach (var kvPair in item)
        {
            if (!dtDoubles.ContainsKey(kvPair.Key))
            {
                dtDoubles.Add(kvPair.Key, new List<double> {kvPair.Value});
            }
            else
            {
                dtDoubles[kvPair.Key].Add(kvPair.Value);
            }
        }
    }
