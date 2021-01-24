    internal DbMigrator(DbMigrationsConfiguration configuration, DbContext usersContext, DatabaseExistenceState existenceState, bool calledByCreateDatabase) : base(null)
    {
    	Check.NotNull(configuration, "configuration");
    	Check.NotNull(configuration.ContextType, "configuration.ContextType");
    	_configuration = configuration;
    	_calledByCreateDatabase = calledByCreateDatabase;
    	_existenceState = existenceState;
    	if (usersContext != null)
    	{
    		_usersContextInfo = new DbContextInfo(usersContext);
    	}
    	else
    	{
    		_usersContextInfo = ((configuration.TargetDatabase == null) ?
                new DbContextInfo(configuration.ContextType) :
                new DbContextInfo(configuration.ContextType, configuration.TargetDatabase));
    		if (!_usersContextInfo.IsConstructible)
    		{
    			throw Error.ContextNotConstructible(configuration.ContextType);
    		}
    	}
        // ...
    }
