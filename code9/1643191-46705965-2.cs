    public class EnvironmentVariableConnectionSettings : IConnectionSettings
    {
        public string MyDatabaseConnectionString { get; }
            = Environment.GetEnvironmentVariable("MyDatabaseConnectionString");
    }
