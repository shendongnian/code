    public interface ICacheManager
    {
        IList<T> GetChache<T>();
    }
    public class CacheHelper
    {
        private readonly Dictionary<Type, Func<IEnumerable<object>>> dataRetrievalFuncs;
        private readonly ICacheManager cacheManager;
        public CacheHelper(ICacheManager cacheManager)
        {
            this.cacheManager = cacheManager;
            dataRetrievalFuncs = new Dictionary<Type, Func<IEnumerable<object>>>();
        }
        public void Register<T>(Func<IEnumerable<T>> selector) where T : class
        {
            dataRetrievalFuncs[typeof(T)] = () => (IEnumerable<object>)selector();
        }
        public IList<T> GetCachedItems<T>() where T : class
            => cacheManager.GetChache<T>()??(dataRetrievalFuncs[typeof(T)]() as IEnumerable<T>).ToList();
    }
