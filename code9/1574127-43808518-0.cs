        public class RepositoryCar<Car> where Car : class
        {
            private DbContext context;
            private DbSet<Car> dbSet;
            public RepositoryCar(DbContext context)
            {
                this.context = context;
                this.dbSet = context.Set<Car>();
            }
            public virtual Car GetByID(object id)
            {
                return dbSet.Find(id);
            }
        }
