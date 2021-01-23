       public class DbMigrationsConfigurationBase<TContext> : DbMigrationsConfiguration<TContext>, IDbMigrationsConfiguration<TContext> where TContext : DbContext, IDbContext
    {
        public DbMigrationsConfigurationBase(Func<DbConnection, string, HistoryContext> historyContextFactory)
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Migrations";
            RegisterHistoryContextFactory(historyContextFactory);
        }
        private void RegisterHistoryContextFactory(Func<DbConnection, string, HistoryContext> historyContextFactory)
        {
            foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
            {
                if (!string.IsNullOrEmpty(connectionString.ProviderName))
                {
                    SetHistoryContextFactory(connectionString.ProviderName, historyContextFactory);
                }
            }
        }
        public IDbMigrator GetMigrator()
        {
            return new DbMigratorWrapper(new DbMigrator(this));
        }
    }
