     private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            Activity activity = await result as Activity;
    
            if (activity.Text == "test")
            {
                await context.PostAsync("works");
                context.Wait(MessageReceivedAsync);
            }
            else if (activity.Text == "help")
            {
                context.Call(new HelpDialog(), ResumeAfterHelp);
                await context.PostAsync("Called help dialog!");
            }            
        }
    
        private async Task ResumeAfterHelp(IDialogContext context, IAwaitable<object> result)
        {
            var selection = await result as string;
            context.Wait(MessageReceivedAsync);
        }
