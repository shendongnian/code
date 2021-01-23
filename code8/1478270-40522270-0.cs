	public abstract class BaseService<TEntity, TVm> 
		: IBaseService<TEntity, TVm> 
			where TEntity: Entity 
			where TVm : BaseViewModel<TEntity>
	{
		protected  IBaseRepository<TEntity> Repository;
		protected BaseService(IBaseRepository<TEntity> repository)
		{
			Repository = repository;
		}
		
		private TVm ConvertToViewModel(TEntity model)
		{
			return new TVm
			{
				Id = model.Id,
				Created = model.Created,
				CreatedBy = model.CreatedBy,
				Modified = model.Modified,
				ModifiedBy = model.ModifiedBy,
				Active = model.Active,
			};
		}
		public virtual  List<TVm> GetAll()
		{
			List<TEntity> list = Repository.GetAll().ToList();
			List<TVm> entities = list.ConvertAll(x => ConvertToViewModel(x));
			return entities;
		}
	}
