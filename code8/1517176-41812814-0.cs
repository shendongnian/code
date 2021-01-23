    telemetryClient.TrackDependency(
        "MongoDB",               // The name of the dependency
        query,                   // Text of the query
        DateTime.Now,            // Time that query is executed
        TimeSpan.FromSeconds(0), // Time taken to execute query
        true);                   // Indicates success
