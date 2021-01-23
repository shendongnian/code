    using System.Collections.Concurrent;
    private static ConcurrentDictionary<Type, IList<PropertyInfo>> typeDictionary = new ConcurrentDictionary<Type, IList<PropertyInfo>>();
    public static IList<PropertyInfo> GetPropertiesForType<T>()
    {
        //variables
        var type = typeof(T);
        typeDictionary.TryAdd(type, type.GetProperties().ToList());
        //return
        return typeDictionary[type];
    }
