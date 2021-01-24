	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
	var connectionSettings = new ConnectionSettings(pool)
        // serialize POCO property names verbatim
        .DefaultFieldNameInferrer(s => s);
    var client = new ElasticClient(connectionSettings);
