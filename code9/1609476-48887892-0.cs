    public static void Register()
    {
        var couchbaseServer = ConfigurationManager.AppSettings.Get("CouchbaseServer");
        var username = ConfigurationManager.AppSettings.Get("CouchbaseUser");
        var password = ConfigurationManager.AppSettings.Get("CouchbasePassword");
        ClusterHelper.Initialize(
            new ClientConfiguration
            {
                Servers = new List<Uri> { new Uri(couchbaseServer) },
            },
            new PasswordAuthenticator(username, password));
        var bucketName = ConfigurationManager.AppSettings.Get("CouchbaseTravelBucket");
        EnsureIndexes(bucketName, username, password);
    }
