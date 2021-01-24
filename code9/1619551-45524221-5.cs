	public class GenericEntityRepository<TContext, TEntity> : EntityRepositoryBase<DbContext, TEntity>
		where TContext: DbContext, new()
		where TEntity : EntityBase
	{
		public GenericEntityRepository() : base(new TContext()) { }
	}
