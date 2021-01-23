    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var defaultIndex = "default-index";
    	var connectionSettings = new ConnectionSettings(pool)
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
    	
    	if (client.IndexExists(defaultIndex).Exists)
    		client.DeleteIndex(defaultIndex);
    
        var child = new Child
        {
            Id = Guid.NewGuid(),
            Name = "Child"
        };
    
        var parent = new Parent
        {
            Id = Guid.NewGuid(),
            Name = "Parent",
            Child = child
        };
    
        var anotherParent = new Parent
        {
            Id = Guid.NewGuid(),
            Name = "Another Parent",
            Child = child
        };
    
        var nestedResponse = client.CreateIndex(defaultIndex, i => i
            .Mappings(m => m
                .Map<Parent>(map => map
                    .AutoMap()
                    .Properties(ps => ps
                        .String(s => s
                            .Name(nn => nn.Id)
                            .NotAnalyzed()
                        )
                        .Nested<Child>(n => n
                            .Name(p => p.Child)
                            .AutoMap()
                            .Properties(p => p
                                .String(s => s
                                    .Name(nn => nn.Id)
                                    .NotAnalyzed()
                                )
                            )
                        )
                    )
                )
            )
        );
    
        var indexResult = client.Index<Parent>(parent);
        indexResult = client.Index<Parent>(anotherParent);
    
        var fetchedParent = client.Get<Parent>(parent.Id).Source;
        var fetchedAnotherParent = client.Get<Parent>(anotherParent.Id).Source;
    
        client.Refresh(defaultIndex);
    
        var update = client.UpdateByQuery<Parent>(u => u
            .Query(q => q
                .Nested(n => n
                    .Path(p => p.Child)
                    .Query(qq => qq
                        .Term(t => t.Child.Id, child.Id)
                    )
                )
            )
            .Script("ctx._source.child.name='New Child Name'")
            .Conflicts(Conflicts.Abort)
            .WaitForCompletion()
            .Refresh()
        );
    
        fetchedParent = client.Get<Parent>(parent.Id).Source;
        fetchedAnotherParent = client.Get<Parent>(anotherParent.Id).Source;
    }
    
    
    public class Parent
    {
        public Guid Id { get; set; }
    
        public string Name { get; set; }
    
        public Child Child { get; set;} 
    }
    
    public class Child
    {
        public Guid Id { get; set; }
    
        public string Name { get; set; } 
    }
