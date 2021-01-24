    [LuisIntent("CutOffPoint")]
    public async Task CutOffPoint(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
    {
            await context.PostAsync($"");
            context.Wait(MessageReceived);
    }
