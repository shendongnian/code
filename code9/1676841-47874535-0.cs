    public class MyCache<TKey, TValue>
    {
        // type to store datetime and a value
        private struct CacheItem
        {
            public DateTime RetreivedTime { get; set; }
            public TValue Value { get; set; }
        }
        // the dictionary
        private Dictionary<TKey, CacheItem> _cache = new Dictionary<TKey, CacheItem>();
        private TimeSpan _timeout;
        private Func<TKey, TValue> _resolveFunc;
        public MyCache(TimeSpan timeout, Func<TKey, TValue> resolveFunc)
        {
            // store to fields
            _timeout = timeout;
            _resolveFunc = resolveFunc;
        }
        public TValue this[TKey key]
        {
            get
            {
                CacheItem valueWithDateTime;
                // if nothing is found, you should retreive it by default
                var getNewValue = true;
                // lookup the key
                if (_cache.TryGetValue(key, out valueWithDateTime))
                    getNewValue = valueWithDateTime.RetreivedTime.Add(_timeout) > DateTime.UtcNow;
                // was it found? or expired?
                if (getNewValue)
                    _cache[key] = valueWithDateTime = new CacheItem { RetreivedTime = DateTime.UtcNow, Value = _resolveFunc(key) };
                // return the value
                return valueWithDateTime.Value;
            }
        }
        public void Cleanup()
        {
            var currentDateTime = DateTime.UtcNow;
            foreach (var keyValue in _cache.ToArray())
                if (keyValue.Value.RetreivedTime.Add(_timeout) < currentDateTime)
                    _cache.Remove(keyValue.Key);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cache = new MyCache<string, string>(TimeSpan.FromMinutes(2), (filename) => File.ReadAllText(filename));
            var content = cache["helloworld.txt"];
        }
    }
