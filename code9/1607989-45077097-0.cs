    private async Task HandleSystemMessage(Activity message)
    {
        if (message.Type == ActivityTypes.ConversationUpdate || message.Type == ActivityTypes.ConversationRelationUpdate)
        {
            var reply = message.CreateReply("Hello World!");
            var connector = new ConnectorClient(new Uri(message.ServiceUrl));
            await connector.Conversations.SendToConversationAsync(reply);
        }
    }
