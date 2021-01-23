    public static IMemoizedEnumerable<T> Memoize<T>(this IEnumerable<T> source)
    {
        return new MemoizedEnumerable<T>(source);
    }
    private class MemoizedEnumerable<T> : IMemoizedEnumerable<T>, IDisposable
    {
        private readonly IEnumerator<T> _sourceEnumerator;
        private readonly List<T> _cache = new List<T>();
    
        public MemoizedEnumerable(IEnumerable<T> source)
        {
            _sourceEnumerator = source.GetEnumerator();
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return IsMaterialized ? _cache.GetEnumerator() : Enumerate();
        }
    
        private IEnumerator<T> Enumerate()
        {
            foreach (var value in _cache)
            {
                yield return value;
            }
    
            while (_sourceEnumerator.MoveNext())
            {
                _cache.Add(_sourceEnumerator.Current);
                yield return _sourceEnumerator.Current;
            }
    
            IsMaterialized = true;
        }
    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
        public List<T> Materialize()
        {
            if (IsMaterialized)
                return _cache;
    
            while (_sourceEnumerator.MoveNext())
            {
                _cache.Add(_sourceEnumerator.Current);
            }
    
            return _cache;
        }
    
        public bool IsMaterialized { get; private set; }
    
        void IDisposable.Dispose() => _sourceEnumerator.Dispose();
    }
    
    public interface IMemoizedEnumerable<T> : IEnumerable<T>
    {
        List<T> Materialize();
    
        bool IsMaterialized { get; }
    }
    
