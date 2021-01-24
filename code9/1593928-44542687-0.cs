    public class Repository<TEntity> where TEntity : IHasGuid
    {
        public virtual void Insert(TEntity entity)
        {
            entity.Id = new Guid();
            dbSet.Add(entity);
        }
    }
