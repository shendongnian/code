    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
        }
    
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            if (General.count == 0)
            {
                General.count = 1;
    
                context.Call(FormDialog.FromForm<General>(General.BuildForm, FormOptions.PromptInStart), async (ctx, formResult) => ctx.Wait(this.MessageReceivedAsync));
            }
            else if (General.count >= 1)
            {
                context.Call(FormDialog.FromForm<ProfileForm>(ProfileForm.BuildForm, FormOptions.PromptInStart), async (ctx, formResult) => ctx.Wait(this.MessageReceivedAsync));
            }
        }
    }
