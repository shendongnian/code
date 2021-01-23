    Dictionary<string, List<int>> existingDictionary = new Dictionary<string, List<int>>();
    foreach (var item in result)
    {
        if (existingDictionary.ContainsKey(item.Key))
        {
            existingDictionary[item.Key].AddRange(item.Value);
        }
        else
        {
            existingDictionary.Add(item.Key, item.Value.ToList());
        }
    }
