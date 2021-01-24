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
            var prompt = new CustomPrompt();
            context.Call<string>(prompt, ResumeAfterPromptString);
        }
        private async Task ResumeAfterPromptString(IDialogContext context, IAwaitable<string> result)
        {
            // Do what you want here... But your customPrompt should return a string
            context.Done<object>(null);
        }
    }
