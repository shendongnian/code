    public static void ApplyDatabaseMigrations()
    {
        //Configuration is the class created by Enable-Migrations
        DbMigrationsConfiguration dbMgConfig = new Configuration()
        {
            ContextType = typeof(MyDbContext) //+++++CHANGE ME+++++
        };
        using (var databaseContext = new MyDbContext()) //+++++CHANGE ME+++++
        {
            try
            {
                var database = databaseContext.Database;
                var migrationConfiguration = dbMgConfig;
                migrationConfiguration.TargetDatabase =
                    new DbConnectionInfo(database.Connection.ConnectionString,
                                         "System.Data.SqlClient");
                var migrator = new DbMigrator(migrationConfiguration);
                migrator.Update();
            }
            catch (AutomaticDataLossException adle)
            {
                dbMgConfig.AutomaticMigrationDataLossAllowed = true;
                var mg = new DbMigrator(dbMgConfig);
                var scriptor = new MigratorScriptingDecorator(mg);
                string script = scriptor.ScriptUpdate(null, null);
                throw new Exception(adle.Message + " : " + script);
            }
        }
    }
