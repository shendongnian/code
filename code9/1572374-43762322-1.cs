    internal class TimestampedEntry<T>
    {
        internal DateTimeOffset Timestamp { get; private set; }
        internal T Value { get; private set; }
        internal TimestampedEntry(T value)
        {
            Timestamp = DateTimeOffset.Now;
            Value = value;
        }
    }
    public class ExpiringList<T> 
    {
        private readonly List<TimestampedEntry<T>> _list = new List<TimestampedEntry<T>>();
        private readonly TimeSpan _expiration;
        public ExpiringList(TimeSpan expiration)
        {
            _expiration = expiration;
        }
        public void Add(T item)
        {
            lock (_list)
            {
              _list.Add(new TimestampedEntry<T>(item));              
            }
        }
        public IReadOnlyCollection<T> Read()
        {
            var cutoff = DateTimeOffset.Now - _expiration;
            TimestampedEntry<T>[] result;
            lock (_list)
            {
                result = _list.Where(item => item.Timestamp > cutoff).ToArray();
                _list.Clear();
                _list.AddRange(result);
            }
            return new ReadOnlyCollection<T>(result.Select(item => item.Value).ToList());
        }
    }
