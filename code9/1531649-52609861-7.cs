    private DbContextInfo(Type contextType, DbProviderInfo modelProviderInfo, AppConfig config, DbConnectionInfo connectionInfo, Func<IDbDependencyResolver> resolver = null)
    {
    	_resolver = (resolver ?? ((Func<IDbDependencyResolver>)(() => DbConfiguration.DependencyResolver)));
    	_contextType = contextType;
    	_modelProviderInfo = modelProviderInfo;
    	_appConfig = config;
    	_connectionInfo = connectionInfo;
    	_activator = CreateActivator();
    	if (_activator != null)
    	{
    		DbContext dbContext = CreateInstance();
    		if (dbContext != null)
    		{
    			_isConstructible = true;
    			using (dbContext)
    			{
    				_connectionString = DbInterception.Dispatch.Connection.GetConnectionString(dbContext.InternalContext.Connection, new DbInterceptionContext().WithDbContext(dbContext));
    				_connectionStringName = dbContext.InternalContext.ConnectionStringName;
    				_connectionProviderName = dbContext.InternalContext.ProviderName;
    				_connectionStringOrigin = dbContext.InternalContext.ConnectionStringOrigin;
    			}
    		}
    	}
        public virtual bool IsConstructible => _isConstructible;
    }
