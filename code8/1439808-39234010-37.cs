       public class AsyncCache<FromT, ToT>
        {
            private Func<FromT, Task<ToT>> GetSomethingTheLongWayAsync;
            public AsyncCache(Func<FromT, Task<ToT>> _GetSomethingTheLongWayAsync, int expiration_min)
            {
                GetSomethingTheLongWayAsync = _GetSomethingTheLongWayAsync;
                Expiration = expiration_min;
            }
    
            int Expiration;
    
            private ConcurrentDictionary<FromT, Tuple<Lazy<Task<ToT>>, DateTime>> _cache = 
                new ConcurrentDictionary<FromT, Tuple<Lazy<Task<ToT>>, DateTime>>();
    
    
            private bool IsExpiredDelete(Tuple<Lazy<Task<ToT>>, DateTime> value, FromT key)
            {
                bool _is_exp = (DateTime.Now - value.Item2).TotalMinutes > Expiration;
                if (_is_exp)
                {
                    _cache.TryRemove(key, out value);
                }
                return _is_exp;
            }
            public async Task<ToT> GetSomethingAsync(FromT key)
            {
                var res = _cache.AddOrUpdate(key,
                    t =>  new Tuple<Lazy<Task<ToT>>, DateTime>(new Lazy<Task<ToT>>(
                          () => GetSomethingTheLongWayAsync(key)
                        )
                    , DateTime.Now) ,
                    (k,t) =>
                    {
                        if (IsExpiredDelete(t, k))
                        {
                            return new Tuple<Lazy<Task<ToT>>, DateTime>(new Lazy<Task<ToT>>(
                          () => GetSomethingTheLongWayAsync(k)
                        ), DateTime.Now);
                        }
                        return t;
                    }
    
                    );
                return await res.Item1.Value;
            }
    
        }
