    void Main()
    {
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
        var defaultIndex = "examples";
    	var connectionSettings = new ConnectionSettings(pool)
    		.DefaultIndex(defaultIndex);
    
    	var client = new ElasticClient(connectionSettings);
    
    	if (client.IndexExists(defaultIndex).Exists)
    		client.DeleteIndex(defaultIndex);
    
    	var examples = new[]{
    		new Example(1, new DateTime(2016, 01, 01)),
    		new Example(1, new DateTime(2017, 01, 01)),
    		new Example(2, new DateTime(2016, 01, 01)),
    		new Example(3, new DateTime(2017, 01, 01)),
    	};
    	
    	client.Bulk(b => b
    		.IndexMany(examples)
    		.Refresh(Refresh.WaitFor));
    	
    	client.Search<Example>(s => s
    		.Size(0)
    		.Query(q => +q
    			.DateRange(c => c.Field(p => p.Date)
    				.GreaterThanOrEquals(new DateTime(2016, 01, 01))
    				.LessThan(new DateTime(2018, 01, 01))
    			)
    		)
    		.Aggregations(a => a
    			.Terms("ids_in_2016_and_2017", c => c
    				.Field(f => f.ExampleId)
    				.Size(int.MaxValue)
    				.Aggregations(aa => aa
    					.Filter("ids_only_in_2016", f => f
    						.Filter(ff => +!ff
    							.DateRange(d => d
    								.Field(p => p.Date)
    								.GreaterThanOrEquals(new DateTime(2017, 01, 01))
    								.LessThan(new DateTime(2018, 01, 01))
    							)
    						)
    					)
    				)
    			)
    		)
    	);
    }
    
    public class Example
    {
    	public Example(int exampleId, DateTime date)
    	{
    		ExampleId = exampleId;
    		Date = date;
    	}
    	
    	public int ExampleId { get; set; }
    
    	public DateTime Date { get; set; }
    }
