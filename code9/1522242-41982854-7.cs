    public class CacheHelper
    {
        private readonly Dictionary<Tuple<Type, string>, Func<object, IEnumerable<object>>> dataRetrievalFuncs;
        private readonly ICacheManager cacheManager;
        public CacheHelper(ICacheManager cacheManager)
        {
            this.cacheManager = cacheManager;
            dataRetrievalFuncs = new Dictionary<Tuple<Type, string>, Func<object, IEnumerable<object>>>();
        }
        public void Register<TEntity, TSource>(string name, Func<TSource, IEnumerable<TEntity>> selector)
            where TEntity : class
            where TSource : class
        {
            dataRetrievalFuncs[new Tuple<Type, string>(typeof(TEntity), name)] = source => (IEnumerable<object>)selector((TSource)source)
        }
        public IList<TEntity> GetCachedItems<TEntity>(string name, object source) where TEntity : class
        {
            var data = cacheManager?.GetChache<TEntity>();
            if (data == null)
            {
                data = (dataRetrievalFuncs[new Tuple<Type, string>(typeof(TEntity), name)](source) as IEnumerable<TEntity>).ToList();
                cacheManager?.Add(data, "Maps", 20);
            }
            return data;
        }
    }
