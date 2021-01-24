    class CacheItem<T>
    {
        public T Value { get; }
        public DateTime TimeAdded { get; }
        public bool IsValid => (DateTime.UtcNow - TimeAdded) < _timeToLive;
        private readonly TimeSpam _timeToLive = TimeSpan.FromMinutes(2);
        public CacheItem(T value)
        {
            Value = value;
            TimeAdded = DateTime.UtcNow;
        }
    }
