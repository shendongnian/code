    Dictionary<string, List<int>> keysByValue = new Dictionary<string, List<int>>();
    
    foreach (KeyValuePair<int, string> entry in dictTempKeys {
        List<int> keys;
        bool hasKeys = keysByValue.TryGet(entry.Value, out keys);
        if (!hasKeys) {
            keys = new List<int>();
            keysByValue.Add(entry.Value, keys);
        }
        keys.Add(entry.Key);
    }
