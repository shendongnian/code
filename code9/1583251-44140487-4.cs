    var result = new Dictionary<MyKeyType, MyValueType>(dict1.Count + dict2.Count + dict3.Count
        + dict4.Count + dict5.Count);
    foreach(var pair in dict1) {
        result.Add(pair.Key, pair.Value);
    }
    foreach(var pair in dict2) {
        if (!dict1.ContainsKey(pair.Key)) result.Add(pair.Key, pair.Value);
    }
    foreach(var pair in dict3) {
        if (!result.ContainsKey(pair.Key)) result.Add(pair.Key, pair.Value);
    }
    foreach(var pair in dict4) {
        if (!result.ContainsKey(pair.Key)) result.Add(pair.Key, pair.Value);
    }
    foreach(var pair in dict5) {
        if (!result.ContainsKey(pair.Key)) result.Add(pair.Key, pair.Value);
    }
