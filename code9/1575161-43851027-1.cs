    var listNames = new Dictionary<string, List<int>>();
    listNames.Add(nameof(list_1), list_1);
    listNames.Add(nameof(list_2), list_2);
    listNames.Add(nameof(list_3), list_3);
    listNames.Add(nameof(list_4), list_4);
    string logRes = String.Join(" ", listNames
        .Where(kv => kv.Value.Count < 300)
        .Select(kv => $"Name: {kv.Key} Amount: {kv.Value.Count}"));
