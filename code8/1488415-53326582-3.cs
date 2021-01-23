    public class ConnectionStringWrapperDotNetCoreRetriever : IConnectionStringWrapperRetriever
    {
        public const string ConnectionStringWrapperSettingsJsonElementName = "ConnectionStringWrapperSettings";
        private readonly IConfiguration config;
        public ConnectionStringWrapperDotNetCoreRetriever(IConfiguration cnfg)
        {
            this.config = cnfg;
        }
        public ConnectionStringWrapper RetrieveConnectionStringWrapper()
        {
            ConnectionStringWrapper settings = new ConnectionStringWrapper();
            this.config.Bind(ConnectionStringWrapperSettingsJsonElementName, settings);
            return settings;
        }
    }
