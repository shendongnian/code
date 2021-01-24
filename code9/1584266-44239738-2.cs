    public static V GetOrAddLazy<T, V>(this System.Collections.Concurrent.ConcurrentDictionary<T, Lazy<V>> dictionary, T key, Func<T, V> valueFactory)
    {
          var lazy = dictionary.GetOrAdd(key, new Lazy<V>(() => valueFactory(key), LazyThreadSafetyMode.ExecutionAndPublication));
          return lazy.Value;
    }
