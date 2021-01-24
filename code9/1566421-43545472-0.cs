    else if (message.Type == ActivityTypes.ConversationUpdate)
    {
         if (message.MembersAdded.Any(o => o.Id == message.Recipient.Id))
         {
                 var reply = message.CreateReply("Welcome!");
    
                 ConnectorClient connector = new ConnectorClient(new Uri(message.ServiceUrl));
    
                 await connector.Conversations.ReplyToActivityAsync(reply);
          }
    }
