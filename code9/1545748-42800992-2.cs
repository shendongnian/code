    void Main()
    {
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    	var defaultIndex = "default-index";
    	var connectionSettings = new ConnectionSettings(pool)
    			.DefaultIndex(defaultIndex);
    				
    	var client = new ElasticClient(connectionSettings);
    	
    	if (client.IndexExists(defaultIndex).Exists)
    		client.DeleteIndex(defaultIndex);
    
        client.CreateIndex(defaultIndex, c => c
            .Mappings(ms => ms
                .Map<TicketMessageModel>(m => m
                    .AutoMap()
                    .Properties(p => p
                        .Nested<TicketMessageFilesModel>(n => n
                            .Name(nn => nn.MessageFileList)
                            .AutoMap()
                        )
                    )
                )
            )
        );
    
        var id = "ticketmessage";
    
        client.Index(new TicketMessageModel
        {
            Id = id,
            MessageFileList = new List<UserQuery.TicketMessageFilesModel>
            {
                new TicketMessageFilesModel { Id = "file1" } 
            }
        });
     
        client.Update<TicketMessageModel, object>(id, q => q
            .Script("if (ctx._source.messageFileList == null) { ctx._source.messageFileList = elem; } else { ctx._source.messageFileList += elem; }")
            .Params(d => d
                .Add("elem", new[] { new TicketMessageFilesModel { Id = "file2" } })
            )
        );
    
        var getResponse = client.Get<TicketMessageModel>(id);
    }
    
    public class TicketMessageModel
    {
        public string Id { get; set; }
        public List<TicketMessageFilesModel> MessageFileList { get; set; }
    }
    
    public class TicketMessageFilesModel
    {
        public string Id { get; set; }
    }
