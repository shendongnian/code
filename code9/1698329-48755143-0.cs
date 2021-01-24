	var client = new ElasticClient(settings);
	var messages = new [] 
	{
		new Message 
		{ 
			Id = "1", 
			MessageType = "foo", 
			MessageJson = "{\"name\":\"message 1\",\"content\":\"foo\"}" 
		},	
		new Message 
		{ 
			Id = "2", 
			MessageType = "bar", 
			MessageJson = "{\"name\":\"message 2\",\"content\":\"bar\"}" 
		}	
	};
	
	var indexName = "my-index";
	var bulkRequest = messages.SelectMany(m => 
		new[]
		{
			client.Serializer.SerializeToString(new
				{
					index = new
					{
						_index = indexName,
						_type = m.MessageType,
						_id = m.Id
					}
				}, SerializationFormatting.None),
			m.MessageJson
		});
		
	var bulkResponse = client.LowLevel.Bulk<BulkResponse>(string.Join("\n", bulkRequest) + "\n");
