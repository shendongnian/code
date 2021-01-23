	private static readonly Dictionary<Type, Type> s_RepositorySuperTypes = new Dictionary<Type, Type> {
		{ typeof(BaseRepository<Country>), typeof(CountryRepository) }
	};
	public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity {
		if (_repositories == null) {
			_repositories = new Hashtable();
		}
		var type = typeof(TEntity).Name;
		if (_repositories.ContainsKey(type)) {
			return (IRepository<TEntity>)_repositories[type];
		}
		var closedRepositoryType = typeof(BaseRepository<>).MakeGenericType(typeof(TEntity));
		if (s_RepositorySuperTypes.ContainsKey(closedRepositoryType)) {
			closedRepositoryType = s_RepositorySuperTypes[closedRepositoryType];
		}
		_repositories.Add(type, Activator.CreateInstance(closedRepositoryType, _context));
		return (IRepository<TEntity>)_repositories[type];
	}
