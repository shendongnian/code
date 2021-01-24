    public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
    {
        var message = await result;
    
        //We need to keep this data so we know who to send the message to. Assume this would be stored somewhere, e.g. an Azure Table
        ConversationStarter.toId = message.From.Id;
        ConversationStarter.toName = message.From.Name;
        ConversationStarter.fromId = message.Recipient.Id;
        ConversationStarter.fromName = message.Recipient.Name;
        ConversationStarter.serviceUrl = message.ServiceUrl;
        ConversationStarter.channelId = message.ChannelId;
        ConversationStarter.conversationId = message.Conversation.Id;
    
        await context.PostAsync("Please wait, we're processing...");
    
        Processing();
    }
    
    
    public async Task Processing()
    {
        //replace the task.delay() method with your task.
        await Task.Delay(30000).ContinueWith((t) =>
        {
            ConversationStarter.Resume(ConversationStarter.conversationId, ConversationStarter.channelId);
        });
    
    }
