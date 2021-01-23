    public class Document
    {
    	public Dictionary<string, object> Data { get; set; }
    }
    var client = new ElasticClient();
	client.CreateIndex("my-index", c => c
		.Mappings(m => m
			.Map<Document>(mm => mm
				.AutoMap()
				.Properties(p => p
					.Object<Dictionary<string, object>>(o => o
						.Name(n => n.Data)
					)
				)
			)
		)
	);
