    public static Dictionary<object, TValue> GenericToDictionary<TValue>(this IEnumerable<TValue> source, string propName)
    {
        Dictionary<object, TValue> result = new Dictionary<object, TValue>();
        foreach (var obj in source)
        {
            result[obj.GetType().GetProperty(propName).GetValue(obj)] = obj;
        }
        return result;
    }
