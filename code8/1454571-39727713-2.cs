	var match = new BsonDocument
	{
		{
			"$group",
			new BsonDocument
				{
					{ "_id", "$Id"  },
					{ "lastModifiedId", new BsonDocument
						{
							{
								"$last", "$_id"
							}
						}}
				}
		}
	};
	var pipeline = new[] { match };
	var result = collection.Aggregate(pipeline);
