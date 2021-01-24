    using (var client = AppContext.DefaultServiceClientFactory.CreateServiceClient("localhost"))
    {
        var query = new QueryExecutor(client);
        using (var reader = query.ExecuteReader("SELECT * FROM foo"))
        {
            //...
        }
    }
