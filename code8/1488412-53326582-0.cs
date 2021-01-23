    public class ConnectionStringEntry
    {
        public String Name { get; set; }
        public String ConnectionString { get; set; }
        public String ProviderName { get; set; }
        public ConnectionStringEntry()
        {
        }
        public ConnectionStringEntry(String name, String connectionString)
            : this(name, connectionString, null)
        {
        }
        public ConnectionStringEntry(String name, String connectionString, String providerName)
        {
            this.Name = name;
            this.ConnectionString = connectionString;
            this.ProviderName = providerName;
        }
    }
