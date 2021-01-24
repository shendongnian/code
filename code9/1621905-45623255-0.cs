    public static class Injector
    {
        private static readonly ConcurrentDictionary<Guid, object> _dict = new ConcurrentDictionary<Guid, object>();
        public static Guid Store(object value)
        {
            var key = Guid.NewGuid();
            _dict.TryAdd(key, value);
            return key;
        }
        public static object Retrieve(Guid guid)
        {
            if (!_dict.TryRemove(guid, out var result))
            {
                throw new Exception("Key not found");
            }
            return result;
        }
    }
