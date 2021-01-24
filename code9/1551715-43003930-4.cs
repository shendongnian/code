    public static Dictionary<object, object> ToDictionary(this IDictionary dict)
    {
        return dict.Keys.Cast<object>().ToDictionary(k => k, k => dict[k]);
    }
    
    // usage
    // kv is a KeyValuePair<object, object>
    foreach (var kv in myIDictionary.ToDictionary())
    {
    }
