    var connectionString = "server=(local);database=Store;integrated security=yes;";
    
    var dbFactory = new SqlServerDatabaseFactory()
    {
    	ConnectionString = connectionString
    };
    
    var db = dbFactory.Import();
    
    var project = new EfCoreProject()
    {
    	Name = "Store",
    	Database = db,
    	OutputDirectory = "C:\\Temp\\Store"
    };
    
    project.BuildFeatures();
    
    project
    	.GenerateEntities()
    	.GenerateAppSettings()
    	.GenerateMappingDependences()
    	.GenerateMappings()
    	.GenerateDbContext()
    	.GenerateContracts()
    	.GenerateRepositories();
