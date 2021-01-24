    public class CacheHelper
    {
        private class Key: IEquatable<Key>
        {
            public Type EntityType { get; }
            public Type ProviderType { get; }
            public string Name { get; }
            public Key(string name, Type entityType, Type providerType)
            {
                Name = name;
                EntityType = entityType;
                ProviderType = providerType;
            }
            public bool Equals(Key other) =>
                Name == other.Name && EntityType == other.EntityType && ProviderType == other.ProviderType;
            public override bool Equals(object obj)
                => obj is Key && Equals(obj as Key);
            public override int GetHashCode()
                => Name.GetHashCode() ^ EntityType.GetHashCode() ^ ProviderType.GetHashCode();
        }
        private readonly Dictionary<Key, Func<object, IEnumerable<object>>> dataRetrievalFuncs;
        private readonly ICacheManager cacheManager;
        public CacheHelper(ICacheManager cacheManager)
        {
            this.cacheManager = cacheManager;
            dataRetrievalFuncs = new Dictionary<Key, Func<object, IEnumerable<object>>>();
        }
        public void Register<TEntity, TProvider>(string name, Func<TProvider, IEnumerable<TEntity>> selector) where TEntity : class
        {
            dataRetrievalFuncs[new Key(name, typeof(TEntity), typeof(TProvider))] = 
                provider => selector((TProvider)provider);
        }
        public IList<TEntity> GetCachedItems<TEntity>(string name, object provider, int lifeTime = 20) where TEntity : class
        {
            var data = cacheManager?.Get<TEntity>(name);
            if (data == null)
            {
                if (dataRetrievalFuncs.TryGetValue(
                        new Key(name, typeof(TEntity), provider.GetType()), out var func))
                {
                    data = (func(provider) as IEnumerable<TEntity>)?.ToList();
                    cacheManager?.Add(data, name, lifeTime);
                }
                else
                    throw new InvalidOperationException("Specified cache is not registered.");
            }
            return data;
        }
    }
