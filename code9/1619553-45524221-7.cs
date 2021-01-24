	public class GenericEntityRepository<TEntity> : EntityRepositoryBase<DbContext, TEntity>
		where TEntity : EntityBase
	{
		public GenericEntityRepository(ApplicationDbContext dbContext) : base(dbContext) { }
	}
