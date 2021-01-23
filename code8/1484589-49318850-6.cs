    public class SpAsyncEnumerableQueryable<T> : IAsyncEnumerable<T>, IQueryable<T>
    {
        private readonly IAsyncEnumerable<T> _spItems;
        public Expression Expression => throw new NotImplementedException();
        public Type ElementType => throw new NotImplementedException();
        public IQueryProvider Provider => throw new NotImplementedException();
    
        public SpAsyncEnumerableQueryable(params T[] spItems)
        {
            _spItems = spItems.ToAsyncEnumerable();
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return _spItems.ToEnumerable().GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        IAsyncEnumerator<T> IAsyncEnumerable<T>.GetEnumerator()
        {
            return _spItems.GetEnumerator();
        }
    }
