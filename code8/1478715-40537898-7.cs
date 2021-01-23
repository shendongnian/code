    public static IMemoizedEnumerable<T> Memoize<T>(this IEnumerable<T> source)
    {
        return new MemoizedEnumerable<T>(source);
    }
    private class MemoizedEnumerable<T> : IMemoizedEnumerable<T>
    {
        private readonly IEnumerator<T> _sourceEnumerator;
        private readonly List<T> _cache = new List<T>();
    
        public MemoizedEnumerable(IEnumerable<T> source)
        {
            _sourceEnumerator = EnumerateSource(source).GetEnumerator();
        }
               
        private IEnumerable<T> EnumerateSource(IEnumerable<T> source)
        {
            foreach (var value in source)
            {
                _cache.Add(value);
                yield return value;
            }
    
            IsMaterialized = true;
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
        public List<T> Materialize()
        {
            if (IsMaterialized)
                return _cache;
    
            while (_sourceEnumerator.MoveNext()) { }
    
            return _cache;
        }
    
        public bool IsMaterialized { get; private set; }            
    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public interface IMemoizedEnumerable<T> : IEnumerable<T>
    {
        List<T> Materialize();
    
        bool IsMaterialized { get; }
    }
    
