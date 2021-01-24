    private static async Task StartDirectMessage(string msAppId, string msAppPassword, string connectorClientUrl, string channelId, string fromId, string fromName, string recipientId, string recipientName, string message, string locale, CancellationToken token)
    {
        // Init connector
        MicrosoftAppCredentials.TrustServiceUrl(connectorClientUrl, DateTime.Now.AddDays(7));
        var account = new MicrosoftAppCredentials(msAppId, msAppPassword);
        var connector = new ConnectorClient(new Uri(connectorClientUrl), account);
        // Init conversation members
        ChannelAccount channelFrom = new ChannelAccount(fromId, fromName);
        ChannelAccount channelTo = new ChannelAccount(recipientId, recipientName);
        // Create Conversation
        var conversation = await connector.Conversations.CreateDirectConversationAsync(channelFrom, channelTo);
        // Create message Activity and send it to Conversation
        IMessageActivity newMessage = Activity.CreateMessageActivity();
        newMessage.Type = ActivityTypes.Message;
        newMessage.From = channelFrom;
        newMessage.Recipient = channelTo;
        newMessage.Locale = (locale ?? "en-US");
        newMessage.ChannelId = channelId;
        newMessage.Conversation = new ConversationAccount(id: conversation.Id);
        newMessage.Text = message;
        await connector.Conversations.SendToConversationAsync((Activity)newMessage);
    }
