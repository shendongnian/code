    private Dictionary<TKey, TValue> NestedCopy<TKey, TValue>(
        Dictionary<TKey, TValue> nestedDict)
    {
        var retDict = new Dictionary<TKey, TValue>();
        foreach (var dict in nestedDict)
        {
            if (typeof(TValue).IsGenericType && typeof(TValue).GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                retDict[dict.Key] = (TValue)NestedCopy((dynamic)dict.Value);
            }
            else
            {
                retDict[dict.Key] = dict.Value;
            }
        }
        return retDict;
    }
