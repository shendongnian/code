    private async Task SendWelcomeMessageAsync(IDialogContext context)
    {
        await context.PostAsync("Hi, I'm the Basic Multi Dialog bot. Let's get started.");
        context.Call(new NameDialog(), this.NameDialogResumeAfter);
    }
  
