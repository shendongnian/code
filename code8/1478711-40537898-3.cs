    public static IEnumerable<T> ToCached<T>(this IEnumerable<T> source)
    {
        return new CachedEnumerable<T>(source);
    }
    
    private class CachedEnumerable<T> : IEnumerable<T>        
    {            
        private readonly IEnumerator<T> _sourceEnumerator;
        private readonly List<T> _cache = new List<T>();
    
        public CachedEnumerable(IEnumerable<T> source)
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
    
        public IEnumerator<T> GetEnumerator()
        {
            return Enumerate().GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
