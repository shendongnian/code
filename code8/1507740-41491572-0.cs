    var list = new Dictionary<int, string>
    {
        { 0, "hat" },
        { 1, "mat" },
        { 2, "fat" }
    };
    var item = list.FirstOrDefault(kvp => kvp.Value == "hat");
    // Remove by value
    list.Remove(item.Key);
    // Remove by key
    list.Remove(0);
