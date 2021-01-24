    private static void InitializeDatabaseUsingEF()
    {
      System.Data.Entity.Database.SetInitializer(
        new System.Data.Entity.MigrateDatabaseToLatestVersion<
          MyDataContext,
          Migrations.Configuration>("ConnectionString.PostgreSql (Npgsql)"));
      using (var db = new MyDataContext())
      {
        db.Database.Initialize(true);        
      }
    }
