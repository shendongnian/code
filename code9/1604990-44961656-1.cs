    private class SimpleMembershipInitializer 
    {
        public SimpleMembershipInitializer() 
        {
    	    // initializer settings here
    
            WebSecurity.InitializeDatabaseConnection("AdventureWorksDatabase", "mvcUser", "userID", "userName", autoCreateTables: false);
        }
    }
