    Database.SetInitializer(new MigrateDatabaseToLatestVersion<T, DbMigrationsConfiguration<T>>());
            try
            {
                using (var ctx = new T())
                {
                    ctx.Database.Initialize(true);
                }
            }
            catch (Exception e)
            {
            }
