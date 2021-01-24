    [LuisIntent("Greeting")]
    public async Task Greeting(IDialogContext context, LuisResult result)
    {
        context.Call(new GuesserDialog(), this.ResumeAfterOptionDialog);
    }
