    private static IDocumentStore InitRavenDb(string connectionString)
    {
        var optsBuilder = ConnectionStringParser<RavenConnectionStringOptions>.FromConnectionString(connectionString);
        optsBuilder.Parse();
        var opts = optsBuilder.ConnectionStringOptions;
    
        return new DocumentStore
        {
            Url = opts.Url,
            ApiKey = opts.ApiKey,
            DefaultDatabase = opts.DefaultDatabase,
        }.Initialize(true);
    }
    var connectionString = Configuration.GetConnectionString("DefaultConnection");
    services.AddSingleton(_ => InitRavenDb(connectionString));
