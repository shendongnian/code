    // Somewhere in your logic...
    context.Call(new CurrentDialog(), ResumeAfterCurrentDialog);
    // On your class:
    private async Task ResumeAfterCurrentDialog(IDialogContext context, IAwaitable<string> result)
    {
		// You are entering here after "context.Done(...)" in the CurrentDialog. To know the "result" value, take a look at what in the OptionSelected in CurrentDialog => it can be null for the options of the list, or the value in "answer" if it's not one of the options
		// So we only have to test if it's not null, and then send the message again to the bot by using the "context.Activity" value
		var resultText = await result;
		if (resultText != null)
		{
			// Send the message again. It's already the message stored in context.Activity ;)
			IMessageActivity msg = (IMessageActivity)context.Activity;
			await this.MessageReceivedAsync(context, new AwaitableFromItem<IMessageActivity>(msg));
		}
    }
