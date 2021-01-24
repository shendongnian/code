    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        var activity = await argument;
        if (activity.Text != "")
        {
            var input = activity.Text;
            string url = "http://example.com/search?q={input}"
            var request = WebRequest.Create("url");
            var response = await request.GetResponseAsync();
            //TODO:
        }
        context.Wait(MessageReceivedAsync);
    }
