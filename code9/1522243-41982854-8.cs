    public interface ICacheManager
    {
        IList<T> GetChache<T>(string name);
        void Add<T>(IList<T> data, string Id, int timeOut);
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
            dataRetrievalFuncs[new Tuple<Type, string>(typeof(T), name)] = 
                () => (IEnumerable<object>)selector();
        }
        public IList<T> GetCachedItems<T>(string name) where T : class
        {
            var data = cacheManager?.GetChache<T>();
            if (data == null)
            {
                data = (dataRetrievalFuncs[new Tuple<Type, string>(typeof(T), name)]() as IEnumerable<T>).ToList();
                cacheManager.Add(data, name, 20);
            }
            return data;
        }
    }
