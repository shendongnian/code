    var x = new Dictionary<string, object>();
    x.Add("B", "F");
    x.Add("A", "D");
    var y = new Dictionary<string, object>();
    y.Add("B", "G");
    Dictionary<string, object>[] dictionaries = new Dictionary<string, object>[]
    {
            x,
            y
    };
    var result = dictionaries.SelectMany(dict => dict)
                         .ToLookup(pair => pair.Key, pair => pair.Value)
                         .ToDictionary(group => group.Key, group => group.ToList()); /* here */
