    private static Dictionary<TKey, TValue> NestedCopy<TKey, TValue>(
        Dictionary<TKey, TValue> nestedDict)
    {
        var retDict = new Dictionary<TKey, TValue>();
        Func<TValue, TValue> clone;
        if (typeof(TValue).IsGenericType && typeof(TValue).GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            clone = v => NestedCopy((dynamic)v);
        }
        else
        {
            clone = v => v;
        }
        foreach (var dict in nestedDict)
        {
            retDict[dict.Key] = clone(dict.Value);
        }
        return retDict;
    }
