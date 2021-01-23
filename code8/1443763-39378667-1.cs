    private void Main() //or application_start
    {
        //init
        GenerateDatabaseTargetQueries();
   
        //update when config changes
        LogManager.ConfigurationReloaded += (sender, args) => GenerateDatabaseTargetQueries();
    }
   
    public void GenerateDatabaseTargetQueries()
    {
        var databaseTargets = LogManager.Configuration.AllTargets.OfType<DatabaseTarget>();
        foreach (var databaseTarget in databaseTargets)
        {
            //todo good init capacity for StringBuilder
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("INSERT INTO [dbo].[Log]");
            foreach (var dbParameter in databaseTarget.Parameters)
            {
                //append all the parameters to the query
            }
            databaseTarget.CommandText = queryBuilder.ToString();
        }
    }
