    var message = new Activity()
                    {
                        ChannelId = ChannelIds.Directline,
                        From = new ChannelAccount(userId, userName),
                        Recipient = new ChannelAccount(botId, botName),
                        Conversation = new ConversationAccount(id: conversationId),
                        ServiceUrl = serviceUrl
                    }.AsMessageActivity();
    using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
    {
        var botDataStore = scope.Resolve<IBotDataStore<BotData>>();
        var key = new AddressKey()
        {
            BotId = message.Recipient.Id,
            ChannelId = message.ChannelId,
            UserId = message.From.Id,
            ConversationId = message.Conversation.Id,
            ServiceUrl = message.ServiceUrl
        };
        var userData = await botDataStore.LoadAsync(key, BotStoreType.BotUserData, CancellationToken.None);
    
        userData.SetProperty("key 1", "value1");
        userData.SetProperty("key 2", "value2");
    
        await botDataStore.SaveAsync(key, BotStoreType.BotUserData, userData, CancellationToken.None);
        await botDataStore.FlushAsync(key, CancellationToken.None);
    }
