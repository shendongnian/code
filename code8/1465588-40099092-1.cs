    public class OnceOnlyConcurrent<TKey, TValue>
    {
        private readonly ConcurrentDictionary<TKey, Lazy<TValue>> _dictionary = new ConcurrentDictionary<TKey, Lazy<TValue>>();
        public TValue GetOrAdd(TKey key, Func<TValue> computation)
        {
            var result = _dictionary.AddOrUpdate(key, _ => new Lazy<TValue>(computation, LazyThreadSafetyMode.ExecutionAndPublication), (_, v) => v);
            return result.Value;
        }
    }
 
