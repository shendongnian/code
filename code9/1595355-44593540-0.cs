    public override async Task StartAsync(IDialogContext context)
    {
        // Force 1st message
        await MessageReceived(context, new AwaitableFromItem<IMessageActivity>((IMessageActivity)context.Activity));
    }
