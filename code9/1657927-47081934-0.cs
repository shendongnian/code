    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueFactory)
    {
        if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
        if (valueFactory == null) throw new ArgumentNullException(nameof(valueFactory));
        TValue value;
        if (!dictionary.TryGetValue(key, out value))
        {
            value = valueFactory.Invoke(key);
            dictionary.Add(key, value);
        }
        return value;
    }
