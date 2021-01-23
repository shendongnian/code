    var pool = new SingleNodeConnectionPool(new Uri(uri));
                    var settings = new ConnectionSettings(pool, connectionSettings => new MyJsonNetSerializer(connectionSettings))
                        .DefaultIndex("seetickets_search_results")
                        .DisableDirectStreaming();
    
                    _elasticClient = new ElasticClient(settings);
