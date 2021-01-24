    private static readonly Dictionary<Type, Object> _NullValues = new Dictionary<Type, Object>()
    {
        { typeof(String), String.Empty }
    };
    public static object Null<T>(this T o)
    {
        object ret;
        return _NullValues.TryGetValue(typeof(T), out ret)
            ? ret : default(T);
    }
