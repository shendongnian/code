    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
        Activity reply = null;
        if (activity.Type == ActivityTypes.Message)
        {
            int length = (activity.Text ?? string.Empty).Length;
            reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
        }
        else if (activity.Type == ActivityTypes.ConversationUpdate)
        {
            reply = message.CreateReply("Welcome");
        }
        if (reply != null) 
        {
            await connector.Conversations.SendToConversationAsync((Activity)reply);
        }
    }
