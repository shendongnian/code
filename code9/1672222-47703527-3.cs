        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }
       private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
    
            var child = new CustomPromptInt64("Number between 1 and 3", "Please try again", 3, min: 1, max: 3);
            context.Call<long>(child, ResumeAfterClarification);
        }
    
        private async Task ResumeAfterClarification(IDialogContext context, IAwaitable<long> result)
        {
            var number = await result;
            context.Done(true);
        }
