    private static StackExchange.Redis.IDatabase _database;
    static JsonSerializerSettings _redisJsonSettings = new JsonSerializerSettings {
        ContractResolver = new SerializeAllContractResolver(),
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
    public void SetAll<T>(Dictionary<string, T> data, int cacheTime)
    {
        TimeSpan expiration = new TimeSpan(0, cacheTime, 0);
        var list = new List<Task<bool>>();
        foreach (var item in data)
        {
            string serializedObject = JsonConvert.SerializeObject(
                item.Value, Formatting.Indented, _redisJsonSettings);
            list.Add(_database.StringSetAsync(item.Key, serializedObject, expiration));
        }
        Task.WhenAll(list.ToArray());
    }
