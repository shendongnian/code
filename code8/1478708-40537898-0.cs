    public static IEnumerable<T> ToCached<T>(this IEnumerable<T> source)
    {
        return new CachedEnumerable<T>(source);
    }
    private class CachedEnumerable<T> : IEnumerable<T>
    {
        private Lazy<List<T>> _lazyList;
        public CachedEnumerable(IEnumerable<T> input )
        {
            _lazyList = new Lazy<List<T>>(input.ToList);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _lazyList.Value.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
