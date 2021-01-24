    static Dictionary<Type, PropertyInfo> DictionaryOfILists = typeof(MasterInfo)
        .GetProperties()
        .Where(v => v.PropertyType.IsGenericType && v.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
        .ToDictionary(v => v.PropertyType, v => v);
    public IList<T> GetEntityList<T>()
    {
        return DictionaryOfILists[typeof(IList<T>)].GetValue(this) as IList<T>;
    }
