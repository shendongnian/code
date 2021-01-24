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
            await context.PostAsync("RootDialog.MessageReceivedAsync");
            await context.Forward(new LuisTestDialog(), AfterLuisDialog, activity);            
        }
    
        private async Task AfterLuisDialog(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("RootDialog.AfterLuisDialog");            
        }
    }
    
    [LuisModel("xxx", "xxx")]
    [Serializable]
    public class LuisTestDialog : LuisDialog<object>
    {
        public async override Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("LuisTestDialog.StartAsync");
            await base.StartAsync(context);
        }
    
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("LuisTestDialog.None");
            context.Done(true);
        }
    
        protected async override Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            await context.PostAsync("LuisTestDialog.MessageReceived");
            await base.MessageReceived(context, item);
        }
    }
