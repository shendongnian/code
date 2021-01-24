    using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, activity))
    {
        var token = new CancellationToken();
        var botData = scope.Resolve<IBotData>();
        await botData.LoadAsync(token);
        var task = scope.Resolve<IDialogTask>();
                           
        var child = new TestDialog();                        
        var interruption = child.Do(new ResumeAfterCall().ResumeAfter);
    
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
    
            [Serializable]
            public class ResumeAfterCall
            {
                public async Task<IMessageActivity> ResumeAfter(IBotContext context, IAwaitable<object> result)
                {
                    return await result as IMessageActivity;                
                }
            }
