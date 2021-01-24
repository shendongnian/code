    private async Task NameDialogResumeAfter(IDialogContext context, IAwaitable<string> result)
    {
        try
        {
            this.name = await result;
            context.Call(new AgeDialog(this.name), this.AgeDialogResumeAfter);
        }
        catch (TooManyAttemptsException)
        {
            await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");
            await this.SendWelcomeMessageAsync(context);
        }
    }
