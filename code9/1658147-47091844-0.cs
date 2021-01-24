	public abstract class BaseEntity
	{
		public DateTime? DeletedOn { get; set; }
	}
	public class NotDeletedFilter<TEntity> 
		where TEntity : BaseEntity
	{
		public IQueryable<TEntity> Filter(IQueryable<TEntity> entities)
		{
			return entities.Where(e => e.DeletedOn == null);
		}
	}
