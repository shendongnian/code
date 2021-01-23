    IList<MyObject> list;
    if (dictionary.TryGetValue(key, out list))
    {
        foreach (var item in list)
        {
            ...
        }
    }
