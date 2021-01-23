    public async Task ResumeAndPromptPlatformAsync(IDialogContext context, IAwaitable<bool> result)
    {
        await context.PostAsync("Input Received");
        context.Done(this);
    }
