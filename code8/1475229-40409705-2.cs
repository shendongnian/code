    ConnectorClient connector = new ConnectorClient(new Uri(callbackInfo.ServiceUrl));
     
            var newMessage = Activity.CreateMessageActivity();
            newMessage.Type = ActivityTypes.Message;
            newMessage.Conversation = new ConversationAccount(id: callbackInfo.ConversationId);
            newMessage.TextFormat = "xml";
            newMessage.Text = message.Text;
    
            await connector.Conversations.SendToConversationAsync(newMessage as Activity);
