    using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, activity))
    {
        var token = new CancellationToken();
        var botData = scope.Resolve<IBotData>();
        await botData.LoadAsync(token);
        var task = scope.Resolve<IDialogTask>();
    
        var child = new FeedbackDialog();
        var interruption = child.Void(task);
    
        try
        {
            task.Call(interruption, null);
            await task.PollAsync(token);
        }
        finally
        {
            await botData.FlushAsync(token);
        }
    }
