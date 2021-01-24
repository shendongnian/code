	var list = await _mongoCollection.Aggregate()
		.Match(mes => chatIdsObject.Contains(mes.ChatId))
		.SortBy(mes => mes.ChatId)
		.ThenByDescending(mes => mes.CreateDateTime)
		.Group(new JsonProjectionDefinition<ChatMessages>(@"{ 
            '_id' : { 'ChatId' : '$ChatId' },
            'LastMessage' : { '$first' : '$$CURRENT' }
        }"))
		.ToListAsync();
