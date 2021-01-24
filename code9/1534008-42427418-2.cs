    public interface IGenericRepository<T, Key>
        where T : BaseEntity<Key>
    {
        IQueryable<T> GetAll();     // No need to async IQueryable
        Task<T> GetAsync(Key id);
        Task<T> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
