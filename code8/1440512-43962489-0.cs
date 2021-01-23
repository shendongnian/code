    public static class Cache
    {
        /// <summary>
        /// Actual cache storage for data.
        /// </summary>
        private static Dictionary<string, object> _cache = new Dictionary<string, object>();
        /// <summary>
        /// Adds/changes an object to the cache.
        /// </summary>
        /// <param name="key">The identifier of stored object to access it.</param>
        /// <param name="obj">The object to store</param>
        public static void Set(string key, object obj)
        {
            if (string.IsNullOrEmpty(key))
                throw new Exception("key must be a non empty string");
            if (_cache.ContainsKey(key))
                _cache[key] = obj;
            else
                _cache.Add(key, obj);
        }
        /// <summary>
        /// Get the cached object by key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            var obj = _cache.ContainsKey(key) ? _cache[key] : null;
            return (T)obj;
        }
        /// <summary>
        /// Removes an object.
        /// </summary>
        /// <param name="key">The identifier of stored object</param>
        public static void Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new Exception("key must be a non empty string");
            if (_cache.ContainsKey(key))
                _cache.Remove(key);
        }
    }
