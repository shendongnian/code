    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        if (activity.Type == ActivityTypes.Message)
        {
             await Conversation.SendAsync(activity, () => new RootDialog());
        }
    }
    [Serializable]
    public class RootDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            PromptDialog.Text(context, MessageReceived, "How are You?");
        }
        private async Task MessageReceived(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            context.Done(message);
        }
    }
