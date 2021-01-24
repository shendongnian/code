    public class MyDalClass
    {
        protected readonly DbContext context;
        public MyDalClass(DbContext context)
        {
            this.context = context;
        }
        public List<TEntity> GetAll<TEntity>()
        {
            return context.Set<TEntity>().ToList();
        }
    }
