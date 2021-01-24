    public sealed class RepositoryFactory
    {
        public static RepositoryFactory Instance = new RepositoryFactory();
    
        // Here is custom repository types
        private IDictionary<Type, Func<DbContext, object>> GetCustomFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
            {
                // { typeof(IOrderLinesRepository), dbContext => new OrderLinesRepository(dbContext) },
            };
        }
    
        // Custom repository types
        private IDictionary<Type, Type> GetRepositoryTypes()
        {
            return new Dictionary<Type, Type>
            {
                { typeof(OrderLine), typeof(IOrderLinesRepository) }
            };
        }
    
        private Func<DbContext, object> GetDefaultFactory<T>()
            where T : class
        {
            return dbContext => new GenericRepository<T>(dbContext);
        }
        private Func<DbContext, object> GetFactory(Type factoryType)
        {
            if (factoryType == null) return null;
            Func<DbContext, object> factory;
            var factories = GetCustomFactories();
            factories.TryGetValue(factoryType, out factory);
            return factory;
        }
        public Type GetRepoType(Type type)
        {
            var types = GetRepositoryTypes();
            Type repoType;
            types.TryGetValue(type, out repoType);
            return repoType;
        }
        public IGenericRepository<TEntity> MakeRepositoryByEntity<TEntity>(DbContext dbContext) where TEntity : class
        {
            var type = this.GetRepoType(typeof(TEntity));
            var f = this.GetFactory(type) ?? GetDefaultFactory<TEntity>();
    
            var repo = f(dbContext);
            return (IGenericRepository<TEntity>)repo;
        }
    
        public TRepo MakeRepository<TRepo, TEntity>(DbContext dbContext)
            where TRepo : class, IGenericRepository<TEntity>
            where TEntity : class
        {
            var repo = this.MakeRepositoryByEntity<TEntity>(dbContext);
            try
            {
                return (TRepo)repo;
            }
            catch (InvalidCastException)
            {
                throw new Exception($"Registered repository for entity ${typeof(TEntity).FullName} does not implement {typeof(TRepo).FullName}");
            }
        }
