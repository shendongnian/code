    void Main()
    {
        var connectionSettings = new ConnectionSettings()
            .DefaultIndex("default-index");
        var client = new ElasticClient(connectionSettings);
    
        client.CreateIndex("projects", c => c
    		.Mappings(m => m
    			.Map<Project>(mm => mm
    				.AutoMap()
    			)
    		)
    	);
    }
    
    [ElasticsearchType(Name = "project")]
    public class Project
    {
    	[Keyword]
    	public Guid Id { get; set; }
    	
    	[Keyword]
    	public string OwnerIdCode { get; set; }
    }
