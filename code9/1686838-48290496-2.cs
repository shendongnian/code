    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
    
            return Task.CompletedTask;
        }
        private bool proceed;
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            PromptDialog.Choice(context,
                this.ResumeAfter,
                options: new string[] { "Yes", "No" },
                prompt: "Are you ready to continue?",
                retry: "Not a valid option",
                attempts: 3);
    
        }
        
        public async Task ResumeAfter(IDialogContext context, IAwaitable<string> argument)
        {
            var message = await argument;
    
            //this sets bool-proceed to false if message is QUIT, for example
            await ProcessTextMessage(context, message);
    
            bool proceed =true;
            if (proceed)
            {
                bool result;
                if (bool.TryParse(message, out result) && result)
                {
                    //do stuff for YES
                }
                else
                {
                    //this is NO
                    await context.PostAsync("What else can I help you with?");
                    context.Done("DONE");
                }
            }
        }
    
        private async Task ProcessTextMessage(IDialogContext context, string message)
        {
            switch (message)
            {
                case "QUIT":
                    proceed = false;
    
                    await context.PostAsync($"**QUIT** Application was triggered. What else can I help you with today?");
                    context.Done("QUIT");
                    break;
    
                case "RESET":
                    proceed = false;
    
                    await context.PostAsync($"**RESET** Application was triggered.");
                    await StartAsync(context);
                    break;
    
                case "HELP":
                    await context.PostAsync($"Some other actions you can use: **QUIT**, **RESET**, **BACK**.");
                    break;
    
                case "BACK":
                    break;
                default:
                    break;
            }
        }
