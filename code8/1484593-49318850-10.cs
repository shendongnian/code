    public class SpAsyncEnumerableQueryable<T> : IAsyncEnumerable<T>, IQueryable<T>
    {
        private readonly IList<T> listOfSpReocrds;
        
        public Type ElementType => throw new NotImplementedException();
        public IQueryProvider Provider => new Mock<IQueryProvider>().Object;
        
        Expression IQueryable.Expression => throw new NotImplementedException();
        public SpAsyncEnumerableQueryable()
        {
            this.listOfSpReocrds = new List<T>();
        }        
        public void Add(T spItem) // this is new method added to allow xxx.Add(new T) style of adding sp records...
        {
            this.listOfSpReocrds.Add(spItem);
        }
        public IEnumerator<T> GetEnumerator()
        {
           return this.listOfSpReocrds.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        IAsyncEnumerator<T> IAsyncEnumerable<T>.GetEnumerator()
        {
            return listOfSpReocrds.ToAsyncEnumerable().GetEnumerator();
        }
    }
