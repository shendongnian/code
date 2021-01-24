    public class Faq
    {
        public string Question { get; set; }
    }
 	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
	var defaultIndex = "default-index";
	var connectionSettings = new ConnectionSettings(pool)
			.DefaultIndex(defaultIndex)
            .DefaultFieldNameInferrer(s => s);
				
	var client = new ElasticClient(connectionSettings);
	
	if (client.IndexExists(defaultIndex).Exists)
		client.DeleteIndex(defaultIndex);
    client.CreateIndex(defaultIndex, c => c
        .Mappings(m => m
            .Map<Faq>(mm => mm
                // let NEST infer mapping from the POCO
                .AutoMap()
                // override any inferred mappings explicitly
                .Properties(p => p
                    .String(s => s
                        .Name(n => n.Question)
                        .Fields(f => f
                            .String(ss => ss
                                .Name("raw")
                                .NotAnalyzed()
                            )
                        )
                    )
                )
            )
        )
    );   
