    public class PersistedGrantStore : IPersistedGrantStore
	{
		private readonly ILogger logger;
		private readonly IPersistedGrantService persistedGrantService;
		public PersistedGrantStore(IPersistedGrantService persistedGrantService, ILogger<PersistedGrantStore> logger)
		{
			this.logger = logger;
			this.persistedGrantService = persistedGrantService;
		}
		
		public Task StoreAsync(PersistedGrant token)
		{
			var existing = this.persistedGrantService.Get(token.Key);
			try
			{
				if (existing == null)
				{
					logger.LogDebug("{persistedGrantKey} not found in database", token.Key);
					var persistedGrant = token.ToEntity();
					this.persistedGrantService.Add(persistedGrant);
				}
				else
				{
					logger.LogDebug("{persistedGrantKey} found in database", token.Key);
					token.UpdateEntity(existing);
					this.persistedGrantService.Update(existing);
				}
			}
			catch (DbUpdateConcurrencyException ex)
			{
				logger.LogWarning("exception updating {persistedGrantKey} persisted grant in database: {error}", token.Key, ex.Message);
			}
			return Task.FromResult(0);
		}
		public Task<PersistedGrant> GetAsync(string key)
		{
			var persistedGrant = this.persistedGrantService.Get(key);
			var model = persistedGrant?.ToModel();
			logger.LogDebug("{persistedGrantKey} found in database: {persistedGrantKeyFound}", key, model != null);
			return Task.FromResult(model);
		}
		public Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
		{
			var persistedGrants = this.persistedGrantService.GetAll(subjectId).ToList();
			var model = persistedGrants.Select(x => x.ToModel());
			logger.LogDebug("{persistedGrantCount} persisted grants found for {subjectId}", persistedGrants.Count, subjectId);
			return Task.FromResult(model);
		}
		public Task RemoveAsync(string key)
		{
			var persistedGrant = this.persistedGrantService.Get(key);
			if (persistedGrant != null)
			{
				logger.LogDebug("removing {persistedGrantKey} persisted grant from database", key);
				try
				{
					this.persistedGrantService.Remove(persistedGrant);
				}
				catch (DbUpdateConcurrencyException ex)
				{
					logger.LogInformation("exception removing {persistedGrantKey} persisted grant from database: {error}", key, ex.Message);
				}
			}
			else
			{
				logger.LogDebug("no {persistedGrantKey} persisted grant found in database", key);
			}
			return Task.FromResult(0);
		}
		public Task RemoveAllAsync(string subjectId, string clientId)
		{
			var persistedGrants = this.persistedGrantService.GetAll(subjectId, clientId);
			logger.LogDebug("removing {persistedGrantCount} persisted grants from database for subject {subjectId}, clientId {clientId}", persistedGrants.Count(), subjectId, clientId);
			try
			{
				this.persistedGrantService.RemoveAll(persistedGrants);
			}
			catch (DbUpdateConcurrencyException ex)
			{
				logger.LogInformation("removing {persistedGrantCount} persisted grants from database for subject {subjectId}, clientId {clientId}: {error}", persistedGrants.Count(), subjectId, clientId, ex.Message);
			}
			return Task.FromResult(0);
		}
		public Task RemoveAllAsync(string subjectId, string clientId, string type)
		{
			var persistedGrants = this.persistedGrantService.GetAll(subjectId, clientId, type);
			logger.LogDebug("removing {persistedGrantCount} persisted grants from database for subject {subjectId}, clientId {clientId}, grantType {persistedGrantType}", persistedGrants.Count(), subjectId, clientId, type);
			try
			{
				this.persistedGrantService.RemoveAll(persistedGrants);
			}
			catch (DbUpdateConcurrencyException ex)
			{
				logger.LogInformation("exception removing {persistedGrantCount} persisted grants from database for subject {subjectId}, clientId {clientId}, grantType {persistedGrantType}: {error}", persistedGrants.Count(), subjectId, clientId, type, ex.Message);
			}
			return Task.FromResult(0);
		}
	}
