	var connectionPool = new SingleNodeConnectionPool(new Uri(myUri));
	var connection = new HttpConnection();
	var serializers = new SerializerFactory((s, v) => s.Converters.Add(new StringEnumConverter()) );
	var settings = new ConnectionSettings(connectionPool, connection, serializers)
	    .DefaultIndex(StatusIndex)
	    .InferMappingFor<MyModel>(m => m
	        .IdProperty(s => s.MyId)
	    );
	var client = new ElasticClient(settings);
