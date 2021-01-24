    public class AsyncEnumerable<T> : IAsyncEnumerable<object>
    {
        private IAsyncEnumerable<T> _source;
    
        public AsyncEnumerable(IAsyncEnumerable<T> source)
        {
            _source = source;
        }
    
        public IAsyncEnumerator<object> GetEnumerator()
        {
            return new AsyncEnumerator<T>(_source.GetEnumerator());
        }
    }
    
    public class AsyncEnumerator<T> : IAsyncEnumerator<object>
    {
        private IAsyncEnumerator<T> _source;
    
        public AsyncEnumerator(IAsyncEnumerator<T> source)
        {
            _source = source;
        }
    
        public object Current => _source.Current;
    
        public void Dispose()
        {
            _source.Dispose();
        }
    
        public async Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            return await _source.MoveNext(cancellationToken);      
        }
    }
    
    public static class AsyncEnumerationExtensions
    {
        public static IAsyncEnumerable<object> ToAsyncEnumerable(this object source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            else if (!source.GetType().GetInterfaces().Any(i => i.GetGenericTypeDefinition() == typeof(IAsyncEnumerable<>)))
            {
                throw new ArgumentException("IAsyncEnumerable<> expected", nameof(source));
            }            
    
            var dataType = source.GetType()
                .GetInterfaces()
                .First(i => i.GetGenericTypeDefinition() == typeof(IAsyncEnumerable<>))
                .GetGenericArguments()[0];
    
            var collectionType = typeof(AsyncEnumerable<>).MakeGenericType(dataType);
    
            return (IAsyncEnumerable<object>)Activator.CreateInstance(collectionType, source);
        }
    }
