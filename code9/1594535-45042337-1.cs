    [LuisIntent("grettings")]
    [LuisIntent("intentfr")]
    public async Task Greeting(IDialogContext context, LuisResult result)
    {
        await context.PostAsync("Welcome");
        context.Wait(MessageReceived);
    }
