    public class MultiLockObjects<TKey>
    {
        private readonly ConcurrentDictionary<TKey, Object>  _multiLocker = new ConcurrentDictionary<TKey, Object>();
        public Object this[TKey key]
        {
            get
            {
                Object lockObj = _multiLocker.GetOrAdd(key, tKey => new Object());
                return lockObj;
            }
        }
    }
