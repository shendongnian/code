    [JsonObject(MemberSerialization.OptIn)]
    public abstract class CECacheBase<T>
    {
        ...
        [JsonProperty("Items")]
        protected ConcurrentDictionary<string, T> items = new ConcurrentDictionary<string, T>();
        ...
    }
