    public class GenericUnitOfWork<TRepo, TEntity> : IDisposable
        where TRepo : Repository<TEntity>
    {
        // Initialization code
        public Dictionary<Type, TRepo> repositories = new Dictionary<Type, TRepo>();
        public TRepo Repository()
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)];
            }
            TRepo repo = (TRepo)Activator.CreateInstance(
                typeof(TRepo),
                new object[] { /*put there parameters to pass*/ });
            repositories.Add(typeof(TEntity), repo);
            return repo;
        }
        // other methods
    }
