    public Session GetASession()
    {
        IDocumentQuery<dynamic> query = database.Client.CreateGremlinQuery<dynamic>(database.Graph, $"g.V()");
        var result = query.ExecuteNextAsync().Result.FirstOrDefault();
        var session = new Data(result); // this solves the problem
        return session;
    }
