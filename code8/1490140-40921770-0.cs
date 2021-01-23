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
    					// log out the request
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
    
    					// log out the response
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
    
    	var stopwords = "stopwords";
    
    	var indexDescriptor = new CreateIndexDescriptor(defaultIndex)
    		.Mappings(ms => ms
    			.Map<Series>(m => m.AutoMap())
    		);
    
    	indexDescriptor.Settings(s => s
    		.NumberOfShards(3)
    		.NumberOfReplicas(2)
    		.Analysis(a => a
    			.CharFilters(c => c.Mapping("&_to_and", mf => mf.Mappings("&=> and ")))
    			.TokenFilters(t => t.Stop("en_stopwords", tf => tf.StopWords(new StopWords(stopwords)).IgnoreCase()))
    			.Analyzers(z => z
    				.Custom("custom_en", ca => ca
    					.CharFilters("html_strip", "&_to_and")
    					.Tokenizer("standard")
    					.Filters("lowercase", "en_stopwords")
    				)
    			)
    		)
    	);
    
    	client.CreateIndex(indexDescriptor);
    
    }
    
    [DataContract]
    [ElasticsearchType(IdProperty = "Id")]
    public class Series
    {
    	[DataMember]
    	[String(Index = FieldIndexOption.Analyzed, Analyzer = "custom_en")]
    	public string Description { get; set; }
    
    	[DataMember]
    	[String(Index = FieldIndexOption.NotAnalyzed)]
    	public HashSet<Role> ReleasableTo { get; set; }
    }
