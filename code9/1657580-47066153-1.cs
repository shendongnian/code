    public interface UnitOfWork<TEntity> : IDisposable
      where TEntity : class
    {
        void Commit();
    }
    
    public interface IDeletableRepositoryBase<TEntity> : IDisposable
      where TEntity : class
    {
        void Delete(object id);
        void Delete(TEntity entity);
    }
    
    public interface IGetRepositoryBase<TEntity> : IDisposable
      where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(object filter);
        TEntity GetById(object id);
        TEntity GetFullObject(object id);
        IQueryable<TEntity> GetPaged(int top = 20, int skip = 0, object orderBy = null, object filter = null);
    }
    
    public interface IUpsertRepositoryBase<TEntity> : IDisposable
      where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
    
    public interface IThirdWaveRepositoryBase<TEntity> : IDisposable, IGetRepositoryBase<TEntity>
      where TEntity : class
    {
        
    }
