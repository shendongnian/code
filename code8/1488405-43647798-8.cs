    public static class ConnectionStringSettingsExtensions
    {
        public static ConnectionStringSettingsCollection ConnectionStrings(this IConfigurationRoot configuration, String section = "ConnectionStrings")
        {
            var connectionStringCollection = configuration.GetSection(section).Get<ConnectionStringSettingsCollection>();
            if (connectionStringCollection == null)
            {
                return new ConnectionStringSettingsCollection();
            }
            return connectionStringCollection;
        }
        public static ConnectionStringSettings ConnectionString(this IConfigurationRoot configuration, String name, String section = "ConnectionStrings")
        {
            ConnectionStringSettings connectionStringSettings;
            var connectionStringCollection = configuration.GetSection(section).Get<ConnectionStringSettingsCollection>();
            if (connectionStringCollection == null ||
                !connectionStringCollection.TryGetValue(name, out connectionStringSettings))
            {
                return null;
            }
            return connectionStringSettings;
        }
    }
