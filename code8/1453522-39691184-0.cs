    public interface IRepository<TEntity>
    where TEntity : IEntity<TKey> {
       void Store(TEntity entity);
       void Delete(TKey key);
    }
