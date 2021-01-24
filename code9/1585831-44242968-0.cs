    [LuistIntent("None"))]
    public async Task None(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
    {
       var msg = await activity;
       
       await context.Forward(new QnABot(), Whatever, msg, CancellationToken.None);
    }
