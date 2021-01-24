    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var defaultIndex = "orders";
    	var connectionSettings = new ConnectionSettings(pool)
    			.DefaultIndex(defaultIndex)
    			.InferMappingFor<Order>(m => m
    				.IdProperty(f => f.Customer)
    			)
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
    	
    	if (client.IndexExists(defaultIndex).Exists)
    		client.DeleteIndex(defaultIndex);
    
    	client.CreateIndex(defaultIndex, c => c
    		.Mappings(m => m
    			.Map<Order>(mm => mm.AutoMap())
    			.Map<OrderLine>(mm => mm
    				.Parent<Order>()
    				.AutoMap()
    			)
    		)
    	);
    
    	var orders = new[]
    	{
    		new Order { Customer = "Bilbo Baggins" },
    		new Order { Customer = "Gandalf the Grey" }
    	};
    
    	var orderlines = new Dictionary<string, OrderLine[]>
    	{
    		{ "Bilbo Baggins",
    			new []
    			{
    				new OrderLine { ItemNumber = 1 },
    				new OrderLine { ItemNumber = 2 },
    				new OrderLine { ItemNumber = 3 },
    				new OrderLine { ItemNumber = 4 },
    				new OrderLine { ItemNumber = 5 }
    			}
    		},
    		{ "Gandalf the Grey",
    			new []
    			{
    				new OrderLine { ItemNumber = 1 },
    				new OrderLine { ItemNumber = 2 },
    				new OrderLine { ItemNumber = 3 },
    				new OrderLine { ItemNumber = 4 }
    			}
    		}
    	};
    
    	client.IndexMany(orders);
    
    	foreach (var lines in orderlines)
    	{
    		client.Bulk(b => b
    			.IndexMany(lines.Value, (bi, d) => bi.Parent(lines.Key))
    		);
    	}
    
    	client.Refresh(defaultIndex);
    
    	var queryResult = client.Search<Order>(s => s
    		.Query(q => +q
    			.HasChild<OrderLine>(c => c
    				.Query(cq => +cq.MatchAll())
                    // min number of child documents that must match
    				.MinChildren(5)
    			)
            )
    	);
    }
    
    public class Order
    {
        public string Customer { get; set; }
    }
    
    public class OrderLine
    {
        public int ItemNumber { get; set; }   
    }
