    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All();
        void Remove(int id);
        void Remove(TEntity entity);
        void RemoveRange(IList<TEntity> entities);
        TEntity Find(int id);
        void Add(TEntity entity);
        void AddRange(IList<TEntity> entities);
        void Update(TEntity entity);
        int SaveChanges();
    }
