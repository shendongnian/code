    using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, activity))
    {
        var botData = scope.Resolve<IBotData>();
        await botData.LoadAsync(new System.Threading.CancellationToken());
    
        var stack = scope.Resolve<IDialogStack>();
    }
