    class CacheKey<T> {
        public string Name { get; }
        public string ToString() => Name;
        public CacheKey(string name) { Name = name; }
    }
    public T GetItem<T>(CacheKey<T> key) { ... }
    public CacheKey<Dictionary<string, string>> SecuritySystemParams { get; } = new CacheKey<Dictionary<string, string>>("SecuritySystemParams");
