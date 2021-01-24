    public class SimpleConcurrentDictionary<TKey, TValue> :
      System.Collections.Concurrent.ConcurrentDictionary<TKey, TValue>
    {
      private readonly Func<TKey, TValue> _loadFunc;
      public SimpleConcurrentDictionary(Func<TKey, TValue> loadFunc)
      {
        _loadFunc = loadFunc;
      }
      public TValue GetOrAdd(TKey key) { return GetOrAdd(key, _loadFunc); }
    } 
