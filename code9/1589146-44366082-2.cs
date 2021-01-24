    context.Call(new CurrentDialog(), ResumeAfterCurrentDialog);
    private async Task ResumeAfterCurrentDialog(IDialogContext context, IAwaitable<string> result)
    {
        var option = await result;
        if (option == null)
        {
            // Do you special treatment here when nothing was selected
        }
        // Normal case
    }
