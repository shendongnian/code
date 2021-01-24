	/// <summary>
	///		Facade for the Raven's IAsyncDocumentSession interface to take care of multi-tenanted entities
	/// </summary>
	public class RavenTenantedSession : IAsyncDocumentSession
    {
		private readonly IAsyncDocumentSession _dbSession;
		private readonly string _currentTenantId;
		public IAsyncAdvancedSessionOperations Advanced => _dbSession.Advanced;
		public RavenTenantedSession(IAsyncDocumentSession dbSession, ICurrentTenantIdResolver tenantResolver)
		{
			_dbSession = dbSession;
			_currentTenantId = tenantResolver.GetCurrentTenantId();
		}
		public void Delete<T>(T entity)
		{
			if (entity is ITenantedEntity tenantedEntity && tenantedEntity.TenantId != _currentTenantId)
				throw new ArgumentException("Attempt to delete a record for another tenant");
			_dbSession.Delete(entity);
		}
		public void Delete(string id)
		{
			throw new NotImplementedException("Deleting by ID hasn't been implemented");
		}
		#region SaveChanges & StoreAsync---------------------------------------
		public Task SaveChangesAsync(CancellationToken token = new CancellationToken()) => _dbSession.SaveChangesAsync(token);
		public Task StoreAsync(object entity, CancellationToken token = new CancellationToken())
		{
			SetTenantIdOnEntity(entity);
			return _dbSession.StoreAsync(entity, token);
		}
		public Task StoreAsync(object entity, string changeVector, string id, CancellationToken token = new CancellationToken())
		{
			SetTenantIdOnEntity(entity);
			return _dbSession.StoreAsync(entity, changeVector, id, token);
		}
		public Task StoreAsync(object entity, string id, CancellationToken token = new CancellationToken())
		{
			SetTenantIdOnEntity(entity);
			return _dbSession.StoreAsync(entity, id, token);
		}
		private void SetTenantIdOnEntity(object entity)
		{
			var tenantedEntity = entity as ITenantedEntity;
			if (tenantedEntity != null)
				tenantedEntity.TenantId = _currentTenantId;
		}
		#endregion SaveChanges & StoreAsync------------------------------------
		public IAsyncLoaderWithInclude<object> Include(string path)
		{
			throw new NotImplementedException();
		}
		public IAsyncLoaderWithInclude<T> Include<T>(Expression<Func<T, string>> path)
		{
			throw new NotImplementedException();
		}
		public IAsyncLoaderWithInclude<T> Include<T, TInclude>(Expression<Func<T, string>> path)
		{
			throw new NotImplementedException();
		}
		public IAsyncLoaderWithInclude<T> Include<T>(Expression<Func<T, IEnumerable<string>>> path)
		{
			throw new NotImplementedException();
		}
		public IAsyncLoaderWithInclude<T> Include<T, TInclude>(Expression<Func<T, IEnumerable<string>>> path)
		{
			throw new NotImplementedException();
		}
		#region LoadAsync -----------------------------------------------------
		public async Task<T> LoadAsync<T>(string id, CancellationToken token = new CancellationToken())
		{
			T entity = await _dbSession.LoadAsync<T>(id, token);
			if (entity == null
			 ||	entity is ITenantedEntity tenantedEntity && tenantedEntity.TenantId == _currentTenantId)
				return entity;
			throw new ArgumentException("Incorrect ID");
		}
		public async Task<Dictionary<string, T>> LoadAsync<T>(IEnumerable<string> ids, CancellationToken token = new CancellationToken())
		{
			Dictionary<string, T> entities = await _dbSession.LoadAsync<T>(ids, token);
			
			if (typeof(T).GetInterfaces().Contains(typeof(ITenantedEntity)))
				return entities.Where(e => (e.Value as ITenantedEntity)?.TenantId == _currentTenantId).ToDictionary(i => i.Key, i => i.Value);
			return null;
		}
		#endregion LoadAsync --------------------------------------------------
		#region Query ---------------------------------------------------------
		public IRavenQueryable<T> Query<T>(string indexName = null, string collectionName = null, bool isMapReduce = false)
		{
			var query = _dbSession.Query<T>(indexName, collectionName, isMapReduce);
			if (typeof(T).GetInterfaces().Contains(typeof(ITenantedEntity)))
				return query.Where(r => (r as ITenantedEntity).TenantId == _currentTenantId);
			
			return query;
		}
		public IRavenQueryable<T> Query<T, TIndexCreator>() where TIndexCreator : AbstractIndexCreationTask, new()
		{
			var query = _dbSession.Query<T, TIndexCreator>();
			var lastArgType = typeof(TIndexCreator).BaseType?.GenericTypeArguments?.LastOrDefault();
			if (lastArgType != null && lastArgType.GetInterfaces().Contains(typeof(ITenantedEntity)))
				return query.Where(r => (r as ITenantedEntity).TenantId == _currentTenantId);
			return query;
		}
		#endregion Query ------------------------------------------------------
		public void Dispose() => _dbSession.Dispose();
	}
