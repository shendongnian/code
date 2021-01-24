    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;
    
    namespace SuggestedActions.Dialogs
    {
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
                var reply = activity.CreateReply("I have colors in mind, but need your help to choose the best one.");
                reply.Type = ActivityTypes.Message;
                reply.TextFormat = TextFormatTypes.Plain;
                reply.SuggestedActions = new Microsoft.Bot.Connector.SuggestedActions()
                {
                    Actions = new List<CardAction>()
                    {
                        new CardAction(){ Title = "Blue", Type=ActionTypes.ImBack, Value="Blue" },
                        new CardAction(){ Title = "Red", Type=ActionTypes.ImBack, Value="Red" },
                        new CardAction(){ Title = "Green", Type=ActionTypes.ImBack, Value="Green" }
                    }
                };
                // return our reply to the user
                await context.PostAsync(reply);
                context.Wait(MessageReceivedAsync);
            }
        }
    }
