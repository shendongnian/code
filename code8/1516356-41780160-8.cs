	public class Context : IDisposable
	{
		private HashSet<Object> _entities;
		public TEntity Create<TEntity>()
		{
			var entity = ThirdPartyLib.Create(typeof(TEntity));
			_entities.Add(entity);
			return entity;
		}		
		
		public void Save<TEntity>(TEntity entity)
		{
			if (!_entities.Contains(entity))
				throw new InvalidOperationException();
			...;
		}
	}
