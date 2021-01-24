    public interface IPersistedGrantService
	{
		void Add(PersistedGrantInfo persistedGrant);
		void Update(PersistedGrantInfo existing);
		PersistedGrantInfo Get(string key);
		IEnumerable<PersistedGrantInfo> GetAll(string subjectId);
		IEnumerable<PersistedGrantInfo> GetAll(string subjectId, string clientId);
		IEnumerable<PersistedGrantInfo> GetAll(string subjectId, string clientId, string type);
		void Remove(PersistedGrantInfo persistedGrant);
		void RemoveAll(IEnumerable<PersistedGrantInfo> persistedGrants);
	}
