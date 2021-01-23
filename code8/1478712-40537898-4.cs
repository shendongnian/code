    public static IMemoizedEnumerable<T> Memoize<T>(this IEnumerable<T> source)
    {
        return new MemoizedEnumerable<T>(source);
    }
    
    public interface IMemoizedEnumerable<T> : IEnumerable<T>
    {
        List<T> GetCache();
    
        bool IsComplete { get; }
    }
    
    private class MemoizedEnumerable<T> : IMemoizedEnumerable<T>
    {
        private readonly IEnumerator<T> _sourceEnumerator;
        private readonly List<T> _cache = new List<T>();
    
        public MemoizedEnumerable(IEnumerable<T> source)
        {
            _sourceEnumerator = EnumerateSource(source).GetEnumerator();
        }
    
        public List<T> GetCache()
        {
            if (IsComplete)
                return _cache;
    
            while (_sourceEnumerator.MoveNext()) {}
    
            return _cache;
        }
    
        public bool IsComplete { get; private set; }
    
        private IEnumerable<T> EnumerateSource(IEnumerable<T> source)
        {
            foreach (var value in source)
            {
                _cache.Add(value);
                yield return value;
            }
    
            IsComplete = true;
        }
    
        private IEnumerable<T> Enumerate()
        {
            foreach (var value in _cache)
            {
                yield return value;
            }
    
            while (_sourceEnumerator.MoveNext())
            {
                yield return _sourceEnumerator.Current;
            }
        }
    
        public IEnumerator<T> GetEnumerator() => Enumerate().GetEnumerator();
    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
