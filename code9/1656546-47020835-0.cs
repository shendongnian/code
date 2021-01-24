    void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
    {
         if (!TryAdd(key, value))
         {
              throw new ArgumentException(GetResource("ConcurrentDictionary_KeyAlreadyExisted"));
        }
    }
