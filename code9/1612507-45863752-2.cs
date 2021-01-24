    public class DbContextResolverHelper
    {
        private static readonly ConcurrentDictionary<Type, DbName> TypeDictionary = new ConcurrentDictionary<Type, DbName>();
        public static DbContext ResolveDbContext<TEntity>(IComponentContext c) where TEntity : class, IEntity
        {
            var type = typeof(DbSet<TEntity>);
            var dbName = TypeDictionary.GetOrAdd(type, t =>
            {
                var typeOfDatabase1 = typeof(Database1);
                var entityInDatabase1 = typeOfDatabase1 .GetProperties().FirstOrDefault(p => p.PropertyType == type);
                return entityInDatabase1 != null ? DbName.Db1: DbName.Db2;
            });
            return c.ResolveKeyed<DbContext>(dbName);
        }
    }
