            You need to update the context, in order to do this you have two possibilities: 
            1. manual migration
            2. automatic migration
            
              For manual migration please read [https://msdn.microsoft.com/en-us/library/jj591621(v=vs.113).aspx][1] 
            
            For automatic migration you can do something like this: 
            
            public YourContext(string dbConnectionString) :
                        base(dbConnectionString)
                    {
                        Database.SetInitializer(new MigrateDatabaseToLatestVersion<YourContext, YourContextConfiguration>());
                    } 
        
         internal sealed class YourContextConfiguration: DbMigrationsConfiguration<YourContext>
            {
                public YourContextConfiguration()
                {
        #if DEBUG
                    AutomaticMigrationsEnabled = true;
                    AutomaticMigrationDataLossAllowed = true;
        #else
                    AutomaticMigrationsEnabled = false;
                    AutomaticMigrationDataLossAllowed = false;
        
        #endif
                }
        
                protected override void Seed(YourContext context)
                {
                    base.Seed(context);
                }
            }
    
    
      [1]: https://msdn.microsoft.com/en-us/library/jj591621(v=vs.113).aspx
