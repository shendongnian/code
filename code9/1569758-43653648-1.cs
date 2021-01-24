    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }
    
        private async Task ResumeAfterForm(IDialogContext context, IAwaitable<ProfileForm> result)
        {
            if (context.PrivateConversationData.TryGetValue("Name", out string name))
            {
                context.Call(new QnADialog(), MessageReceivedAsync);
            }
            else
            {
                await context.PostAsync("Something went wrong.");
                context.Wait(MessageReceivedAsync);
            }
        }
    
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var form = new FormDialog<ProfileForm>(new ProfileForm(), ProfileForm.BuildForm, FormOptions.PromptInStart);
            context.Call(form, ResumeAfterForm);
        }
    }
