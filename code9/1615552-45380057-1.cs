    Conversation.UpdateContainer(builder =>
    {
        // Registers the class the saves the last send message for each conversation.
        builder
            .RegisterKeyedType<StoreLastActivity, IBotToUser>()
            .InstancePerLifetimeScope();
    
        // Adds the class on the IBotToUser chain.
        builder
            .RegisterAdapterChain<IBotToUser>
            (
                typeof(AlwaysSendDirect_BotToUser),
                typeof(AutoInputHint_BotToUser),
                typeof(MapToChannelData_BotToUser),
                typeof(StoreLastActivity),
                typeof(LogBotToUser)
            )
            .InstancePerLifetimeScope();
    }
