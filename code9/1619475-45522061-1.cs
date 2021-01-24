    private static Dictionary<TKey, TValue> NestedCopy<TKey, TValue>(
        Dictionary<TKey, TValue> nestedDict)
    {
        var reflectionMethod = typeof(Program).GetMethod("NestedCopy", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        var retDict = new Dictionary<TKey, TValue>();
        foreach (var dict in nestedDict)
        {
            if (typeof(TValue).IsGenericType && typeof(TValue).GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                var methodToCall = reflectionMethod.MakeGenericMethod(typeof(TValue).GetGenericArguments());
                retDict[dict.Key] = (TValue)methodToCall.Invoke(null, new object[] { dict.Value });
            }
            else
            {
                retDict[dict.Key] = dict.Value;
            }
        }
        return retDict;
    }
