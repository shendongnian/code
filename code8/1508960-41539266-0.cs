    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var connectionSettings = new ConnectionSettings(pool)
    			.DefaultIndex("foo");
    	var client = new ElasticClient(connectionSettings);
    
        // POST http://localhost:9200/foo/bar/_search
        // Will try to deserialize all _source to instances of Bar
        client.Search<Bar>(s => s
            .MatchAll()
        );
    
        // POST http://localhost:9200/foo/_search
        // Will try to deserialize all _source to instances of Bar
        client.Search<Bar>(s => s
            .AllTypes()
            .MatchAll()
        );
    
        // POST http://localhost:9200/_search
        // Will try to deserialize all _source to instances of Bar
        client.Search<Bar>(s => s
            .AllTypes()
            .AllIndices()
            .MatchAll()
        );
    
        connectionSettings = new ConnectionSettings(pool)
                .InferMappingFor<Bar>(m => m
                    .IndexName("bars")
                    .TypeName("barbar")
                );
             
        client = new ElasticClient(connectionSettings);
    
        // POST http://localhost:9200/bars/barbar/_search
        // Will try to deserialize all _source to instances of Bar
        client.Search<Bar>(s => s
            .MatchAll()
        );
    
        // POST http://localhost:9200/bars/_search
        // Will try to deserialize all _source to instances of Bar
        client.Search<Bar>(s => s
            .AllTypes()
            .MatchAll()
        );
    
        // POST http://localhost:9200/_all/barbar/_search
        // Will try to deserialize all _source to instances of Bar
        client.Search<Bar>(s => s
            .AllIndices()
            .MatchAll()
        );
    
        // POST http://localhost:9200/_search
        // Will try to deserialize all _source to instances of Bar
        client.Search<Bar>(s => s
            .AllIndices()
            .AllTypes()
            .MatchAll()
        );
    }
    
    
    public class Bar
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public DateTime createdTime { get; set; }
    }
