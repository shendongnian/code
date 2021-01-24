	public class GenericEntityRepository<TContext, TEntity> : EntityRepositoryBase<TContext, TEntity>
		where TContext: DbContext, new()
		where TEntity : EntityBase
	{
		public GenericEntityRepository() : base(new TContext()) { }
	}
