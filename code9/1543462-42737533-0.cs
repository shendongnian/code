        var client = new DiscordClient();
            client.MessageCreated += (s, e) =>
        		{
        			if (!e.Message.IsAuthor && e.Message.ToLower().Contains("roll")){
    /*Code here*/
    }		
        		}
        		EventHandler<MessageEventArgs> handler = new EventHandler<MessageEventArgs>(HandleMessageCreated);
        		client.MessageCreated += handler;
