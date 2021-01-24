    public async Task StartAsync(IDialogContext context)
    {
        // Force the call to MessageReceivedAsync instead of waiting
        await MessageReceivedAsync(context, new AwaitableFromItem<IMessageActivity>(context.Activity.AsMessageActivity()));
    }
