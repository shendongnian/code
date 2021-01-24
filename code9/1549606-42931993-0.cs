    private Dictionary<string, object> _cache = new Dictionary<string, object>();
    public string LabelText => Get<string>(Constants.LabelText);
    private T Get<T>(string resource)
    {
        object value;
        if (!_cache.TryGetValue(resource, out value))
            value = _cache[resource] = GetFromResources(resource);
        return (T)value;
    }
