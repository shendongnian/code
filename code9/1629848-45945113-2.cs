    public class ObjectKeyedCache : ICache<object, object>
    {
        public object GetOrAdd(object key, Func<object, object> valueFactory)
        {
            // Let's ignore the specified key, and just pass in an object!
            return valueFactory(new object());
        }
    }
