    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var defaultIndex = "default-index";
    	var connectionSettings = new ConnectionSettings(pool)
    			.DefaultIndex(defaultIndex);
    				
    	var client = new ElasticClient(connectionSettings);
    	
    	if (client.IndexExists(defaultIndex).Exists)
    		client.DeleteIndex(defaultIndex);
    
        var descriptor = new CreateIndexDescriptor(defaultIndex)
            .Mappings(ms => ms
                .Map<ProviderContent>(m => m
                    .AutoMap()
                    .Properties(p => p
                        .String(s => s
                            .Name(n => n.OrganizationName)
                            .Fields(f => f
                                .String(ss => ss.Name("raw").NotAnalyzed())))
                        .String(s => s
                            .Name(n => n.ServiceCategories)
                            .Analyzer("tab_delim_analyzer")
                        )
                        .GeoPoint(g => g
                            .Name(n => n.Location)
                            .LatLon(true)
                        )
                    )
                )
            )
            .Settings(st => st
                .Analysis(an => an
                    .Analyzers(anz => anz
                        .Custom("tab_delim_analyzer", td => td
                            .Filters("lowercase")
                            .Tokenizer("tab_delim_tokenizer")
                        )
                    )
                    .Tokenizers(t => t
                        .Pattern("tab_delim_tokenizer", tdt => tdt
                            .Pattern(@"\|")
                        )
                    )
                )
            );
        
        client.CreateIndex(descriptor);
    
        // check our custom analyzer does what we think it should
        client.Analyze(a => a
            .Index(defaultIndex)
            .Analyzer("tab_delim_analyzer")
            .Text("|Case Management|Developmental Disabilities")
        );
    
        // index a document and make it immediately available for search
        client.Index(new ProviderContent
        {   
            OrganizationName = "Elastic",
            ServiceCategories = "|Case Management|Developmental Disabilities"
        }, i => i.Refresh());
    
    
        // search for our document. Use a term query in a bool filter clause
        // as we don't need scoring (probably)
        client.Search<ProviderContent>(s => s
            .From(0)
            .Size(10)
            .Sort(so => so
                .Ascending(f => f.OrganizationName)
            )
            .Query(q => +q
                .Term(f => f.ServiceCategories, "developmental disabilities")          
            )
        );
    
    }
    
    public class ProviderContent
    {
        public string OrganizationName { get; set; }
        
        public string ServiceCategories { get; set; }
    
        public GeoLocation Location { get; set; }
    }
