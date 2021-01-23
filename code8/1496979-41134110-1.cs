    public async Task MainScreenSelectionReceived(IDialogContext context, 
                           IAwaitable<IMessageActivity> argument, bool doNotShowPrompt) 
    {
        //Original code here
    }
    public async Task MainScreenSelectionReceived(IDialogContext context, 
                           IAwaitable<IMessageActivity> argument) 
    {
        return await MainScreenSelectionReceived(context, argument, false);
    }
