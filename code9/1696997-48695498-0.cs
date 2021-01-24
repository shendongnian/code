    if (activity.Type == ActivityTypes.Message)
    {
        using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, activity))
        {
            var botData = scope.Resolve<IBotData>();
            await botData.LoadAsync(CancellationToken.None);
                        
            var lcid = botData.PrivateConversationData.GetValueOrDefault<string>("LCID");
            if (!string.IsNullOrEmpty(lcid))                    
                activity.Locale = lcid;
                        
            await botData.FlushAsync(CancellationToken.None);
        }
    
        await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
    }
