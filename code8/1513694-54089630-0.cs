    internal class CosmosDBConnectionString
    {
        public CosmosDBConnectionString(string connectionString)
        {
            // Use this generic builder to parse the connection string
            DbConnectionStringBuilder builder = new DbConnectionStringBuilder
            {
                ConnectionString = connectionString
            };
            if (builder.TryGetValue("AccountKey", out object key))
            {
                AuthKey = key.ToString();
            }
            if (builder.TryGetValue("AccountEndpoint", out object uri))
            {
                ServiceEndpoint = new Uri(uri.ToString());
            }
        }
        public Uri ServiceEndpoint { get; set; }
        public string AuthKey { get; set; }
    }
