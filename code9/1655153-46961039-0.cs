    public class GenericRepository<TEntity> where TEntity : class
    {
        internal SchoolContext context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(SchoolContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        //Other code
    }
