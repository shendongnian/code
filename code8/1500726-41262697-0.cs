    Dictionary<string, Dictionary<string, int>> _storage = new Dictionary<string, Dictionary<string, int>>();
    Dictionary<string, int> x = new Dictionary<string, int>();
    x.Add("x", 2);
    x.Add("z", 2);
    x.Add("y", 2);
    _storage.Add("x", x);
    _storage.Add("z", x);
    _storage.Add("y", x);
     var b = _storage.SelectMany(keyValuePair => keyValuePair.Value)
             .GroupBy(keyValuePair => keyValuePair.Key)
             .ToDictionary(valuePairs => valuePairs.Key, grouping => grouping.Sum(kvp => kvp.Value));
