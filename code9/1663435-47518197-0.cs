    public override void InitializeDatabase(T context)
    {
    	base.InitializeDatabase(context);
    
    	var _historyRepository = migrator.GetType().GetField("_historyRepository", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(migrator);
    	var _existingConnection = _historyRepository.GetType().BaseType.GetField("_existingConnection", BindingFlags.Instance | BindingFlags.NonPublic);
    	_existingConnection.SetValue(_historyRepository, null);
    
    	var x = migrator.GetPendingMigrations();
    	if (x.Any())
    	{
    		migrator.Update();
    		Seed(context);
    	}
    }
