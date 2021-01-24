	public interface IRepositoryReadOnly<TEntity> : IDisposable where TEntity : class
	{
		IQueryable<TEntity> GetAll();
		IQueryable<TEntity> GetAll(object filter);
		TEntity GetById(object id);
		TEntity GetFullObject(object id);
		IQueryable<TEntity> GetPaged(int top = 20, int skip = 0, object orderBy = null, object filter = null);
	}
	public interface IRepository<TEntity> : IRepositoryReadOnly<TEntity> where TEntity : class
	{
		void Delete(object id);
		void Delete(TEntity entity);
	
		void Insert(TEntity entity);
		void Update(TEntity entity);
	
		void Commit();
	}
	
