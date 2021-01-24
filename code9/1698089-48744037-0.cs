    public class AsyncEnumerableQuery<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T> {
        public AsyncEnumerableQuery(IEnumerable<T> enumerable) : base(enumerable) {
        }
        public AsyncEnumerableQuery(Expression expression) : base(expression) {
        }
        public IDbAsyncEnumerator<T> GetAsyncEnumerator() {
            return new InMemoryDbAsyncEnumerator<T>(((IEnumerable<T>) this).GetEnumerator());
        }
        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator() {
            return GetAsyncEnumerator();
        }
        private class InMemoryDbAsyncEnumerator<T> : IDbAsyncEnumerator<T> {
            private readonly IEnumerator<T> _enumerator;
            public InMemoryDbAsyncEnumerator(IEnumerator<T> enumerator) {
                _enumerator = enumerator;
            }
            public void Dispose() {
            }
            public Task<bool> MoveNextAsync(CancellationToken cancellationToken) {
                return Task.FromResult(_enumerator.MoveNext());
            }
            public T Current => _enumerator.Current;
            object IDbAsyncEnumerator.Current => Current;
        }
    }
