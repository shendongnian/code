    class IntentHandler : LuisDialog<object>
    {
        
        private string userToBot;
        protected override async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            var message = await item;
            //No way to get the message in the LuisIntent methods so saving it here
            userToBot = message.Text.ToLowerInvariant();
            if (message.Type != ActivityTypes.Message)
            {
                await base.MessageReceived(context, item);
                return;
            }
            if (!await context.IsUserAuthenticated(m_resourceId))
            {
                await context.Forward(new AzureAuthDialog(m_resourceId), ResumeAfterAuth, message, CancellationToken.None);
            }
            else
            {
                await base.MessageReceived(context, item);
            }
            
        }
        
         private async Task ResumeAfterAuth(IDialogContext context, IAwaitable<string> result)
         {
            var message = await 
            await context.PostAsync(message);
            Activity activity = (Activity)context.Activity;
            
            //Store the saved message back to the activity
            activity.Text = userToBot;
            
            //Reset the saved message
            userToBot = string.Empty;
            //Call the base.MessageReceived to trigger the LUIS intenet
            await base.MessageReceived(context, Awaitable.FromItem(activity));
            
        }
    }
