    [LuisModel("xxxxxxx", "yyyyyyyyyyy")]
    [Serializable]
    public class LuisDialog : LuisDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceived);
        }
    
        [LuisIntent("None")]
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Désolé je n'ai pas compris '{result.Query}'. Veuillez formuler votre question";
    
            await context.PostAsync(message);    
            context.Wait(this.MessageReceived);
        }
    
        [LuisIntent("test")]
        public async Task test(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("nous testons");
            context.Wait(MessageReceived);
        }
        [LuisIntent("yourOtherIntent1")]
        public async Task OtherIntent1(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("fallback 1");
            context.Wait(MessageReceived);
        }
        [LuisIntent("yourOtherIntent2")]
        public async Task OtherIntent1(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("fallback 2");
            context.Wait(MessageReceived);
        }
    
        public async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            var messageHandled = await result;
            if (messageHandled != null)
            {
                await context.PostAsync("Désolé je n'ai pas compris");
                context.Wait(MessageReceived);
            }
        }
    }
