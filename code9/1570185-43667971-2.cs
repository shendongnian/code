    public static Dictionary<string, string> ToSyncDictionary<T>(this T value)
    {
        var syncProperties = from p in typeof(T).GetProperties()
                             let name = p.GetCustomAttribute<SyncProperty>()?.PropertyName
                             where name != null
                             select new {
                                 Name = name,
                                 Value = p.GetValue(value)?.ToString()
                             };
        return syncProperties.ToDictionary(p => p.Name, p => p.Value);
    }
