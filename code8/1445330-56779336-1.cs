    public interface IRepository<T> where T : class
        {
            Task<T> GetByIdAsync(int id);
            IQueryable<T> GetAll();
            void Remove(T entity);
            void Add(T entity);
            void Update(T entity);
            Task<int> SaveChangeAsync();
        }
