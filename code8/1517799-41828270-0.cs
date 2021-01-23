    [LuisIntent("test-intent")]
    public async Task help(IDialogContext context, IAwaitable<IMessageActivity> argument, LuisResult result)
    {
        var activity = await argument;
        await Conversation.SendAsync(activity, () => SimpleFacebookAuthDialog.dialog);
    }
