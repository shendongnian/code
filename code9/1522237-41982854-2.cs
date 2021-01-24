    public interface ICacheManager
    {
        IList<T> GetChache<T>(string name);
    }
    public class CacheHelper
    {
        private readonly Dictionary<Tuple<Type, string>, Func<IEnumerable<object>>> dataRetrievalFuncs;
        private readonly ICacheManager cacheManager;
        public CacheHelper(ICacheManager cacheManager)
        {
            this.cacheManager = cacheManager;
            dataRetrievalFuncs = new Dictionary<Tuple<Type, string>, Func<IEnumerable<object>>>();
        }
        public void Register<T>(string name, Func<IEnumerable<T>> selector) where T : class
        {
            dataRetrievalFuncs[new Tuple(typeof(T), name)] = 
               () => (IEnumerable<object>)selector();
        }
        public IList<T> GetCachedItems<T>(string name) where T : class
            => cacheManager.GetChache<T>(name) ?? 
               (dataRetrievalFuncs[new Tuple(typeof(T), name)]() as IEnumerable<T>).ToList();
    }
