    using (var client = new HdInsightClient("clusterName", "admin", "password"))
    using (var session = await client.CreateSessionAsync(config))
    {
        var sum = await session.ExecuteStatementAsync<int>("val res = 1 + 1\nprintln(res)");
    
        const string sql = "SELECT id, SUM(json.total) AS total FROM cosmos GROUP BY id";
    
        var cosmos = await session.ExecuteCosmosDbSparkSqlQueryAsync<IEnumerable<Result>>
        (
            "cosmosName",
            "cosmosKey",
            "cosmosDatabase",
            "cosmosCollection",
            "cosmosPreferredRegions",
            sql
        );
    }
