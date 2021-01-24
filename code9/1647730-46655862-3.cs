    public static string UpdateDictionaryAndGetOldValue(this Dictionary<string, string> dict, string key, string newVal)
    {
        string oldVal = string.Empty;
        dict.TryGetValue(key, out oldVal);
        dict[key] = newVal;
        return oldVal;
    }
