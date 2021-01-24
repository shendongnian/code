    public static TValue GetOrAdd<TKey, TValue>(
        this IDictionary<TKey, TValue> dictionary,
        TKey key,
        Func<TKey, TValue> valueFactory)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));
        if (key == null)
            throw new ArgumentNullException(nameof(key));
        if (valueFactory == null)
            throw new ArgumentNullException(nameof(valueFactory));
        if (dictionary.TryGetValue(key, out var existingValue))
            return existingValue;
        var value = valueFactory(key);
        dictionary.Add(key, value);
        return value;
    }
