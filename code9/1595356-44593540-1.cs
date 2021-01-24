    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }
        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            if (message.Text.ToLower().Contains("get started") ||
                message.Text.ToLower().Contains("hello") ||
                message.Text.ToLower().Contains("hi"))
            {
                context.Call(new Dialog44592511_EN(), this.ResumeAfterOptionDialog);
            }
            else if (message.Text.ToLower().Contains("démarrer") || message.Text.ToLower().Contains("salut") || message.Text.ToLower().Contains("french"))
            {
                context.Call(new Dialog44592511_FR(), this.ResumeAfterOptionDialog);
            }
            else
            {
                await context.PostAsync($"Ooops! There are some problems with our system");
            }
        }
        private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync($"Resume!");
        }
    }
    [Serializable]
    public class Dialog44592511_FR : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await MessageReceivedAsync(context, new AwaitableFromItem<IMessageActivity>((IMessageActivity)context.Activity));
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            await context.PostAsync($"Vous êtes dans le dialogue FR");
            context.Done<object>(null);
        }
    }
    [Serializable]
    public class Dialog44592511_EN : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await MessageReceivedAsync(context, new AwaitableFromItem<IMessageActivity>((IMessageActivity)context.Activity));
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            await context.PostAsync($"You are in the EN dialog");
            context.Done<object>(null);
        }
    }
