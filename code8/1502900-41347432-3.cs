    namespace MyNamespace
    {
        using System;
        using System.Threading.Tasks;
        using Microsoft.Bot.Builder.Dialogs;
        using Microsoft.Bot.Builder.Internals.Fibers;
        using Microsoft.Bot.Builder.Luis;
        using Microsoft.Bot.Builder.Luis.Models;
        using Microsoft.Bot.Connector;
    
        [Serializable]
        [LuisModel("YourModelId", "YourSubscriptionKey")]
        public class MyLuisDialog : LuisDialog<object>
        {
            [LuisIntent("")]
            [LuisIntent("None")]
            public async Task None(IDialogContext context, LuisResult result)
            {
                string message = "Não entendi, me diga com outras palavras!";
    
                await context.PostAsync(message);
                context.Wait(this.MessageReceived);
            }
    
            [LuisIntent("ChangeInfo")]
            public async Task ChangeInfo(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
            {
                // no need to go to luis again..
                PromptDialog.Text(context, AfterEmailProvided, "Tell me your new email please?");
            }
    
            private async Task AfterEmailProvided(IDialogContext context, IAwaitable<string> result)
            {
                try
                {
                    var email = await result;
    
                    // logic to store your email...
                }
                catch
                {
                    // here handle your errors in case the user doesn't not provide an email
                }
              
              context.Wait(this.MessageReceived);
            }
    
            [LuisIntent("PaymentInfo")]
            public async Task Payment(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
            {
                // logic to retrieve the current payment info..
                var email = "test@email.com";
    
                PromptDialog.Confirm(context, AfterEmailConfirmation, $"Is it {email} your current email?");
            }
    
            private async Task AfterEmailConfirmation(IDialogContext context, IAwaitable<bool> result)
            {
                try
                {
                    var response = await result;
                    
                    // if the way to store the payment email is the same as the one used to store the email when going through the ChangeInfo intent, then you can use the same After... method; otherwise create a new one
                    PromptDialog.Text(context, AfterEmailProvided, "What's your current email?");
                }
                catch
                {
                    // here handle your errors in case the user doesn't not provide an email
                }
                context.Wait(this.MessageReceived);
            }
        }
    }
