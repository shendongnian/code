    private const string DefaultIndexName = "test";
    private const string ElasticSearchServerUri = @"http://localhost:9200";
    private const string UsersIndexName = "users";
    
    void Main()
    {
    	var client = CreateElasticClient();
    
        var users = new[] {
            new User { Code = "XW1234", Name = "John Doe" },
            new User { Code = "AD4567", Name = "Jane Doe" }
        };
        
        client.IndexMany(users);
        
        // refresh the index after indexing so that the documents are immediately 
        // available for search. This is good for testing, 
        // but avoid doing it in production.
        client.Refresh(UsersIndexName);
    
        var result = client.Search<User>(descriptor => descriptor
            .Query(q => q
                .QueryString(queryDescriptor => queryDescriptor
                    .Query("1234")
                    .Fields(fs => fs
                        .Fields(f1 => f1.Code)
                    )
                )
            )
        );
        
        // outputs 1
        Console.WriteLine(result.Total);
    }
    
    public class User
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    
    public IElasticClient CreateElasticClient()
    {
        var settings = CreateConnectionSettings();
        var client = new ElasticClient(settings);
    
        // this is here so that the example can be re-run.
        // Remove this!
        if (client.IndexExists(UsersIndexName).Exists)
        {
            client.DeleteIndex(UsersIndexName);
        }
    
        client.CreateIndex(UsersIndexName, descriptor => descriptor
            .Mappings(ms => ms
                .Map<User>(m => m
                    .AutoMap()
                    .Properties(ps => ps
                        .String(s => s
                            .Name(n => n.Code)
                            .Analyzer("substring_analyzer")
                        )
                    )
                )
            )
            .Settings(s => s
                .Analysis(a => a
                    .Analyzers(analyzer => analyzer
                        .Custom("substring_analyzer", analyzerDescriptor => analyzerDescriptor
                            .Tokenizer("standard")
                            .Filters("lowercase", "substring")
                        )
                    )
                    .TokenFilters(tf => tf
                        .NGram("substring", filterDescriptor => filterDescriptor
                            .MinGram(2)
                            .MaxGram(15)
                        )
                    )
                )
            )
        );
    
        return client;
    }
    
    private static ConnectionSettings CreateConnectionSettings()
    {
        var uri = new Uri(ElasticSearchServerUri);
        var settings = new ConnectionSettings(uri)
            .DefaultIndex(DefaultIndexName)
            .InferMappingFor<User>(d => d
                .IndexName(UsersIndexName)
            );
    
        return settings;
    }
