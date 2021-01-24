	var client = new ElasticClient();
    // using OpType.Create
    client.Index(new Test { Id = 1, Message = "message 1" }, i => i
    	.OpType(OpType.Create)
	);
    // using _create endpoint
	client.Create(new Test { Id = 1, Message = "message 1" });
