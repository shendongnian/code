    List<string> list;
    // Read the dictionary exactly once
    if (!dict.TryGetValue(key, out list))
    {
        list = new List<string>();
        // Write at most once.
        dict[key] = list;
    }
    list.Add(value);
