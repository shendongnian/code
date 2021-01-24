    [Serializable]
    public class QnADialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.PrivateConversationData.TryGetValue("Name", out string name);
            await context.PostAsync($"Hello {name}. The QnA Dialog was started. Ask a question.");
            context.Wait(MessageReceivedAsync);
               
        }
    
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
    
            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;
    
            // return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");
    
            context.Wait(MessageReceivedAsync);
        }
    }
