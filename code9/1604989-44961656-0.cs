    private class SimpleMembershipInitializer 
    {
        public SimpleMembershipInitializer() 
        {
    	    // initializer settings here
    
            var connectionBuilder = new EntityConnectionStringBuilder("AdventureWorksEntities");
            string sqlConnectionString = connectionBuilder.ConnectionString;
    
            WebSecurity.InitializeDatabaseConnection(sqlConnectionString, "mvcUser", "userID", "userName", autoCreateTables: false);
        }
    }
