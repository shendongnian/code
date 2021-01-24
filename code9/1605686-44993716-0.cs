    [Serializable]
    public class SomeDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync); 
        }
        private async Task OnPhoneSet(IDialogContext context, IAwaitable<string> result)
        {
            var res = await result;
        }
        private async Task OnEmailSet(IDialogContext context, IAwaitable<string> result)
        {
            var res = await result;
            PromptDialog.Text(context, OnPhoneSet, "What is the contact's phone number? ");
        }
        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            PromptDialog.Text(context, OnEmailSet, "What is the contact's email? ");
        }
    }
