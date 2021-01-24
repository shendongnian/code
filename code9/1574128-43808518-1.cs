        public class Repository<TEntity> where TEntity : class
        {
            private DbContext context;
            private DbSet<TEntity> dbSet;
            public Repository(DbContext context)
            {
                this.context = context;
                this.dbSet = context.Set<TEntity>();
            }
            public virtual TEntity GetByID(object id)
            {
                return dbSet.Find(id);
            }
        }
