	public class ScopeStore: IScopeStore
	{
		private readonly DbContext _context;
		public ScopeStore(DbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<IdentityServer3.Core.Models.Scope>> FindScopesAsync(IEnumerable<string> scopeNames)
		{
			var models = await List().Where(m => scopeNames.Contains(m.Name)).ToListAsync();
			return AddStandardScopes(models);
		}
		public async Task<IEnumerable<IdentityServer3.Core.Models.Scope>> GetScopesAsync(bool publicOnly = true)
		{
			var models = await List(publicOnly).ToListAsync();
			return AddStandardScopes(models);
		}
		/// <summary>
		/// Gets a list of Scopes
		/// </summary>
		/// <param name="publicOnly">A boolean to show public scopes or not</param>
		/// <returns>The matched Scopes</returns>
		public IQueryable<IdentityServer3.EntityFramework.Entities.Scope> List(bool publicOnly = true, params string[] includes)
		{
			var models = _context.Set<IdentityServer3.EntityFramework.Entities.Scope>();
			if (publicOnly)
				return models.Where(m => m.ShowInDiscoveryDocument);
			
			return models;
		}
		private IEnumerable<IdentityServer3.Core.Models.Scope> AddStandardScopes(IEnumerable<IdentityServer3.EntityFramework.Entities.Scope> scopes)
		{
			var models = scopes.Select(m => m.ToModel()).ToList();
			models.AddRange(StandardScopes.All.ToList());
			return models;
		}
	}
