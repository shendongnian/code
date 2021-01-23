    void Main()
    {
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    
        var connectionSettings = new ConnectionSettings(pool)
            .MapDefaultTypeIndices(d => d
                .Add(typeof(Question), NDC.StackOverflowIndex)
            );
    
    
        var client = new ElasticClient(connectionSettings);
        
        var twoYearsAgo = DateTime.UtcNow.Date.AddYears(-2);
        var yearAgo = DateTime.UtcNow.Date.AddYears(-1);
    
        var searchResponse = client.Search<Question>(s => s
            .Size(0)
            .Query(q => q
                .DateRange(c => c.Field(p => p.CreationDate)
                    .GreaterThan(twoYearsAgo)
                    .LessThan(yearAgo)
                )
            )
            .Aggregations(a => a
                .Terms("unique_users", c => c
                    .Field(f => f.OwnerUserId)
                    .Size(int.MaxValue)
                )
            )
        );
    
        var uniqueOwnerUserIds = searchResponse.Aggs.Terms("unique_users").Buckets.Select(b => b.KeyAsString).ToList();
    
        // 3.83 seconds
        // unique question askers: 795352
        Console.WriteLine($"unique question askers: {uniqueOwnerUserIds.Count}");
    }
