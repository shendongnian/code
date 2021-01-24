    List<string> list = new List<string>() { "item1", "item2" };
    string item3 = "item3";
    List<string> list2 = new List<string>() { "item4", "item5" };
    string item6 = "item6";
    
    string result = string.Join(",", GetConcatenatedValues(list, item3, list2, item6));
    
    public List<string> GetConcatenatedValues(params object[] args)
    {
        List<string> results = new List<string>();
        foreach (var entry in args
        {
            if (entry is List<string>)
                results.AddRange(entry as List<string>);
            else
                results.Add(entry.ToString());
        }
        return results;
    }
