    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : IHasGuid
    {
        internal DataContext context;
        internal DbSet<TEntity> dbSet;
        public virtual void Insert(TEntity entity)
        {
             entity.Id = new Guid();
             dbSet.Add(entity);
        }
    }
