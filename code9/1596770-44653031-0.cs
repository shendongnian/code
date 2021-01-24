    void Main()
    {
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
        var defaultIndex = "default-index";
        var connectionSettings = new ConnectionSettings(pool, new InMemoryConnection())
            .DefaultIndex(defaultIndex)
            .PrettyJson()
            .DisableDirectStreaming()
            .OnRequestCompleted(response =>
                {
                    if (response.RequestBodyInBytes != null)
                    {
                        Console.WriteLine(
                            $"{response.HttpMethod} {response.Uri} \n" +
                            $"{Encoding.UTF8.GetString(response.RequestBodyInBytes)}");
                    }
                    else
                    {
                        Console.WriteLine($"{response.HttpMethod} {response.Uri}");
                    }
    
                    Console.WriteLine();
    
                    if (response.ResponseBodyInBytes != null)
                    {
                        Console.WriteLine($"Status: {response.HttpStatusCode}\n" +
                                 $"{Encoding.UTF8.GetString(response.ResponseBodyInBytes)}\n" +
                                 $"{new string('-', 30)}\n");
                    }
                    else
                    {
                        Console.WriteLine($"Status: {response.HttpStatusCode}\n" +
                                 $"{new string('-', 30)}\n");
                    }
                });
    
        var client = new ElasticClient(connectionSettings);
    
    	var includeAutoLearnedData = false;
    
    	var request = new SearchRequest<Message>
    	{
    		Query = new HasChildQuery
    		{          
    		 	Type = "child",
    			Query = new CommonTermsQuery
    			{
    				Field = Infer.Field<Message>(m => m.Content),
    				Query = "commonterms"
    			}
    			&& (includeAutoLearnedData ? null : +new TermQuery
    			{
    				Field = Infer.Field<Message>(m => m.Content),
    				Value = "term"
    			})
    		}
    	};
    
    	client.Search<Message>(request);
    }
    
    public class Message
    {
        public string Content { get; set; }
    }
