    void Main()
    {
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
        var defaultIndex = "test";
        var connectionSettings = new ConnectionSettings(pool)
                .DefaultIndex(defaultIndex)
    			.DefaultFieldNameInferrer(s => s)
    			.InferMappingFor<MyObject>(m => m
    				.IdProperty(p => p.Id)
    			);
    
        var client = new ElasticClient(connectionSettings);
    
    	if (client.IndexExists(defaultIndex).Exists)
    		client.DeleteIndex(defaultIndex);
    
    	client.CreateIndex(defaultIndex, c => c
    		.Mappings(m => m
    			.Map<MyObject>(mm => mm
    				.AutoMap()
    			)
    		)
    	);
    
    	var objs = Enumerable.Range(0, 10).Select(i =>
    		new MyObject
    		{
    			Id = i.ToString(),
    			Category = (i % 2) == 0 ? "a" : "b",
    			Keywords = (i % 3).ToString()
    		});
    
    	client.IndexMany(objs);
    	
    	client.Refresh(defaultIndex);
    
    	var searchResponse = client.Search<MyObject>(s => s
    		.Query(q => q.Term(P => P.Category, "a"))
    		.Source(f => f.Includes(si => si.Fields(ff => ff.Keywords)))
    		.Aggregations(a => a
    			.Terms("Keywords", t => t
    				.Field(f => f.Keywords)
    				.Size(10)
    			)
    		)
    	);
    
    }
    
    public class MyObject
    {
    	[Keyword]
    	public string Id { get; set; }
    	[Text]
    	public string Category { get; set; }
    	[Text(Fielddata = true)]
    	public string Keywords { get; set; }
    }
