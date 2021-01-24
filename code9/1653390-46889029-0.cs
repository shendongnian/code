    public class MultiLockObjects<TKey>
    {
        private readonly ConcurrentDictionary<TKey, Object>  _multiLocker = new ConcurrentDictionary<TKey, Object>();
        public Object this[TKey key]
        {
            get
            {
                bool contained = _multiLocker.TryGetValue(key, out var lockObj);
                if (!contained)
                {
                    lockObj = new Object();
                    contained = _multiLocker.TryAdd(key, lockObj);
                }
                if(!contained) ;
                // log or throw exception
                return lockObj;
            }
            set
            {
                bool added = _multiLocker.TryAdd(key, new Object());
                if (!added) ;
                    // log or throw exception, could happen if key already contained
            }
        }
    }
