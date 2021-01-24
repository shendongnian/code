	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
	var defaultIndex = "taskmanager";
	var connectionSettings = new ConnectionSettings(pool)
			.DefaultIndex(defaultIndex);
				
	var client = new ElasticClient(connectionSettings);
	
	var customAnalyzer = new CustomAnalyzer
	{
		Tokenizer = "mynGram",
		Filter = new[] { "lowercase" }
	};
	var createIndexRequest = new CreateIndexRequest(defaultIndex)
	{
		Settings = new IndexSettings
		{
			Analysis = new Analysis
			{
				Analyzers = new Analyzers{ { "mynGram", customAnalyzer } },
				Tokenizers = new Tokenizers{ { "mynGram", new NGramTokenizer { MaxGram = 10, MinGram = 2 } } }
			}
		}
	};
	
	client.CreateIndex(createIndexRequest);
