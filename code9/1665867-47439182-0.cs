    using System;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;
    
    namespace chatbot.Dialogs
    {
        [Serializable]
        public class RootDialog : IDialog<object>
        {
            public async Task StartAsync(IDialogContext context)
            {
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
    }
