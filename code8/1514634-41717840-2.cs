    var orderedDictionary = new OrderedDictionary();
    orderedDictionary.Add("something", someObject);
    orderedDictionary.Add("another", anotherObject);
    object[] keys = new object[orderedDictionary.Keys.Count];
    orderedDictionary.Keys.CopyTo(keys, 0);
    for (var dictIndex = orderedDictionary.Count-1; dictIndex > -1; dictIndex--)
    {
        // It gives me the value, but how do I get the key?
        // E.g., "something" and "another".
        var key = orderedDictionary[dictIndex];
        // Get your key, e.g. "something" and "another"
        var key = keys[dictIndex];
    }
