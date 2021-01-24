    public async Task StartAsync(IDialogContext context)
    {
        context.Wait(this.ShowOptions);
    }
    public async virtual Task ShowOptions(IDialogContext context, IAwaitable<IMessageActivity> result)
    {
        var message = await result;
        PromptDialog.Choice<string>(
            context,
            this.OnOptionSelected,
            new List() { ImageOption, ToolOption },
            "Please select one of the following category.",
            "Not a valid option",
            3);
    }
