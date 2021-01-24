    else if (message.Type == ActivityTypes.ContactRelationUpdate)
    {
    	if(message.Action == "add")
    	{
    		var reply = message.CreateReply("WELCOME!!!");
    		ConnectorClient connector = new ConnectorClient(new Uri(message.ServiceUrl));
    		await connector.Conversations.ReplyToActivityAsync(reply);
    	}
    }
