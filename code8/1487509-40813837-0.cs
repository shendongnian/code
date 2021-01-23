    public interface IEntity
    {
        object Key { get; set; }
    }
    public interface IEntity<TKey> : IEntity
    {
        TKey TypedKey { get; set; }
    }
    public class Repository<TEntity>
        where TEntity : IEntity
    {
        public IEntity<TKey> GetOne<TKey>(TKey key)
        {
            ...;
        }
    }
