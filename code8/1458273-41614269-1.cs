        public sealed class MySpecialDatabaseMigrationConfiguration : DbMigrationsConfigurationBase<MySpecialDatabase>
    {
        private static readonly Func<DbConnection, string, HistoryContext> HistoryContextFactory =
            (connection, schema) => new MySpecialDatabaseHistoryContext(connection, schema);
        public MySpecialDatabaseMigrationConfiguration(): base(HistoryContextFactory)
        {
            ContextKey = "MyNamespace.MySpecialDatabase";
        }
    }
