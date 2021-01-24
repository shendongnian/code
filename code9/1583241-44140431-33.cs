    Dictionary<TKey, List<TValue>> result = dict1
        .Union(dict2)
        .Union(dict3)
        .Union(dict4)
        .Union(dict5)
        .GroupBy(e => e.Key, e => e.Value)
        .ToDictionary(g => g.Key, v => v.ToList());
