    void Main()
    {
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    
        var connectionSettings = new ConnectionSettings(pool)
            .MapDefaultTypeIndices(d => d
                .Add(typeof(Question), NDC.StackOverflowIndex)
            );
    
        var client = new ElasticClient(connectionSettings);
        var uniqueOwnerUserIds = new HashSet<int>();
        
        var twoYearsAgo = DateTime.UtcNow.Date.AddYears(-2);
        var yearAgo = DateTime.UtcNow.Date.AddYears(-1);
    
        var searchResponse = client.Search<Question>(s => s
            .Source(sf => sf
                .Include(ff => ff
                    .Field(f => f.OwnerUserId)
                )
            )
            .Size(10000)
            .Scroll("1m")
            .Query(q => q
                .DateRange(c => c
                    .Field(p => p.CreationDate)
                    .GreaterThan(twoYearsAgo)
                    .LessThan(yearAgo)
                )
            )
        );
    
        while (searchResponse.Documents.Any())
        {
            foreach (var document in searchResponse.Documents)
            {
                if (document.OwnerUserId.HasValue)
                    uniqueOwnerUserIds.Add(document.OwnerUserId.Value);
            }
            
            searchResponse = client.Scroll<Question>("1m", searchResponse.ScrollId);
        }
        
        client.ClearScroll(c => c.ScrollId(searchResponse.ScrollId));
    
        // 91.8 seconds
        // unique question askers: 795352
        Console.WriteLine($"unique question askers: {uniqueOwnerUserIds.Count}");
    }
