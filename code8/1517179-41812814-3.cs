    var client = new MongoClient(new MongoClientSettings()
    {
        Server = new MongoServerAddress("localhost"),
        ClusterConfigurator = cb =>
        {
            cb.Subscribe<CommandStartedEvent>(e =>
            {
                telemetryClient.TrackDependency(
                    "MongoDB",               // The name of the dependency
                    e.Command.ToJson()       // Text of the query
                    DateTime.Now,            // Time that query is executed
                    TimeSpan.FromSeconds(0), // Time taken to execute query
                    true);                   // Indicates success
            });
        }
    });
