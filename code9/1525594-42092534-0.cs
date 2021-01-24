    PromptDialog.Confirm(context, ResumeAfterPrompt, "prompt dialogue", "retry dialog", 3);
    private async Task ResumeAfterPrompt(IDialogContext context, IAwaitable<bool> result)
    {
        try
        {
            // try get user response
            bool response = await result;
    
            await context.PostAsync($"You said: {result}");
        }
        catch (TooManyAttemptsException)
        {
            // handle error
        }
       // wait for another message from the user. Could be the same method or a new one following the same signature.
       context.Wait(this.MessageReceivedAsync);
    }
