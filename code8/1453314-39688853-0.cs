    public sealed class GenericUoW : IGenericUoW
    {
        private readonly Dictionary<Type, object> repositories =new Dictionary<Type, object>();
        private readonly DbContext entities;
        public GenericUoW(DbContext entities)
        {
            this.entities = entities;
        }
        public IRepository<T> Repository<T>() where T : class
        {
            if (!repositories.Keys.Contains(typeof(T))) {
                IRepository<T> repo = new GenericRepository<T>(entities);
                repositories.Add(typeof(T), repo);
            }
            return (IRepository<T>)repositories[typeof(T)];
        }
        public void SaveChanges() {
            entities.SaveChanges();
        }
    }
