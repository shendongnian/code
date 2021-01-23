    public class SqlServerDbContextBuilder IDbContextBuilder
    {
        public bool CanHandle(string providerType) => providerType == "SqlServer";
        public T CreateDbContext<T>(connectionString)
        {
            T context = ... // Create the context here
            return context;
        }
    }
