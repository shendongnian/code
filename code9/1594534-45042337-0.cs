    [LuisIntent("grettings")]
    [LuisIntent("intentfr")]
    public async Task Greeting(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
    {
        await context.PostAsync("Welcome");
        context.Wait(MessageReceived);
    }
