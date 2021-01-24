    static class TestExtensions {
        public static IQueryable<T> AsAsyncQueryable<T>(this IEnumerable<T> source) {
            return new TestDbAsyncEnumerable<T>(source);
        }
    }
    internal class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>
    {
        public TestDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }
        public TestDbAsyncEnumerable(Expression expression)
            : base(expression)
        { }
        public IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }
        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }
    }
    internal class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T> {
        private readonly IEnumerator<T> _inner;
        public TestDbAsyncEnumerator(IEnumerator<T> inner) {
            _inner = inner;
        }
        public void Dispose() {
            _inner.Dispose();
        }
        public Task<bool> MoveNextAsync(CancellationToken cancellationToken) {
            return Task.FromResult(_inner.MoveNext());
        }
        public T Current => _inner.Current;
        object IDbAsyncEnumerator.Current => Current;
    }
