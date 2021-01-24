    public class CacheHelper
    {
        private readonly Dictionary<Tuple<Type, string>, Func<object, IEnumerable<object>>> dataRetrievalFuncs;
        private readonly ICacheManager cacheManager;
        public CacheHelper(ICacheManager cacheManager)
        {
            this.cacheManager = cacheManager;
            dataRetrievalFuncs = new Dictionary<Tuple<Type, string>, Func<object, IEnumerable<object>>>();
        }
        public void Register<TEntity, TProvider>(string name, Func<TProvider, IEnumerable<TEntity>> selector)
            where TEntity : class
            where TProvider: class
        {
            dataRetrievalFuncs[new Tuple<Type, string>(typeof(TEntity), name)] =
                provider => (IEnumerable<object>)selector((TProvider)provider)
        }
        public IList<TEntity> GetCachedItems<TEntity>(string name, object provider, int lifeTime = 20)
            where TEntity : class
        {
            var data = cacheManager?.GetChache<TEntity>();
            if (data == null)
            {
                data = (dataRetrievalFuncs[new Tuple<Type, string>( 
                           typeof(TEntity), name)](provider) as IEnumerable<TEntity>)
                       .ToList();
                cacheManager?.Add(data, name, lifeTime);
            }
            return data;
        }
    }
