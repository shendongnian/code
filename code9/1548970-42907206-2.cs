    public class MockDbSet<T> : IDbSet<T> where T : class {
    
        readonly HashSet<T> _data;
        readonly IQueryable _query;
        public MockDbSet() : this(new HashSet<T>()) {            
        }
        public MockDbSet(params T[] entries) : this(new HashSet<T>(entries)) {
        }
        private MockDbSet(IEnumerable<T> data) {
            _data = new HashSet<T>(data);
            _query = _data.AsQueryable();
        }
    
        public T Add(T item) {
            _data.Add(item);
             return item;
        }
    
        public T Remove(T item) {
            _data.Remove(item);
            return item;
        }
        Type IQueryable.ElementType {
            get { return _query.ElementType; }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return _data.GetEnumerator();
        }
    
        // implement other members of IDbSet<T> ...
    }
