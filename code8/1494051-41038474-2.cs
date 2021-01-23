    void Main()
    {
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
        var defaultIndex = "default-index";
        var connectionSettings = new ConnectionSettings(pool)
                .DefaultIndex(defaultIndex);
    
        var client = new ElasticClient(connectionSettings);
        
        client.CreateIndex(defaultIndex, c => c
            .Mappings(m => m
                .Map<Person>(mm => mm
                    .AutoMap()
                )
            )
        );
    
        client.Index(new Person
        {   
            Name = "Jinesh          "
        }, i => i.Refresh(Refresh.WaitFor));
    	
        var searchResponse = client.Search<Person>(s => s
            .Query(q => q
                .Match(m => m
                    .Field(f => f.Name)
                    .Query("Jinesh")
                )
            )
        );
    }
    
    public class Person
    {
        public string Name { get; set; }
    }
