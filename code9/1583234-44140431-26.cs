    Dictionary<TKey, List<TValue>> result = dict1
        .Concat(dict2)
        .Concat(dict3)
        .Concat(dict4)
        .Concat(dict5)
        .GroupBy(e => e.Key, e => e.Value)
        .ToDictionary(g => g.Key, v => v.ToList());
