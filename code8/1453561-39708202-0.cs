    MongoClientSettings settings = new MongoClientSettings();
    settings.Server = new MongoServerAddress(host, 10250);
    settings.UseSsl = true;
    settings.SslSettings = new SslSettings();
    settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;
    MongoIdentity identity = new MongoInternalIdentity(dbName, userName);
    MongoIdentityEvidence evidence = new PasswordEvidence(password);
    settings.Credentials = new List<MongoCredential>()
    {
        new MongoCredential("SCRAM-SHA-1", identity, evidence)
    };
    MongoClient client = new MongoClient(settings);
