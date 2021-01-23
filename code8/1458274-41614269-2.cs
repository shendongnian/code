        public class CreateOrMigrateDatabaseInitializer<TContext, TConfiguration> : IDatabaseInitializer<TContext>
        where TContext : DbContext, IDbContext
        where TConfiguration : IDbMigrationsConfiguration<TContext>, new()
    {
        private readonly string _connection;
        public CreateOrMigrateDatabaseInitializer(string connection, ILogger logger = null)
        {
            Contract.Requires(!string.IsNullOrEmpty(connection), "connection");
            _connection = connection;
        }
        public void InitializeDatabase(TContext context)
        {
            Contract.Requires(context != null, "context");
            IDbMigrationsConfiguration<TContext> configuration = new TConfiguration()
            {
                TargetDatabase = new DbConnectionInfo(_connection)
            };
            if (!context.Database.Exists() || !context.Database.CompatibleWithModel(throwIfNoMetadata: false))
            {
                var migrator = configuration.GetMigrator();
                foreach (string s in migrator.GetPendingMigrations())
                {
                    migrator.Update(s);
                }
            }
            Seed(context);
            context.SaveChanges();
        }
    } 
