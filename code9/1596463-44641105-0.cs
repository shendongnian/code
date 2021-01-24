    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
    
            return Task.CompletedTask;
        }
    
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
    
            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;
    
            // return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");
    
            context.Wait(MessageReceivedAsync2);
        }
    
        private async Task MessageReceivedAsync2(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync($"Second MessageReceived");
    
            context.Wait(MessageReceivedAsync);
        }
    }
