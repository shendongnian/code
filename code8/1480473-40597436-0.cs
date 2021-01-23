    [LuisIntent("Choose category")]
    public async Task ChooseCategory(IDialogContext context, LuisResult result)
    {
        // get category logic..
    
        await context.PostAsync("This is my first question?");
        context.Wait(CaptureFirstQuestionAnswerAsync);
    }
    
    public async Task CaptureFirstQuestionAnswerAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        IMessageActivity message = await argument;
        switch (message.Text.ToLower())
        {
            case "answer 1":
                // do something
                break;
            case "answer 2":
               // do something different
                break;
            default:
               // do something ...
                break;
        }
    
        await context.PostAsync($"This is my second question?");
    
        context.Wait(CaptureSecondQuestionAnswerAsync);
    }
    
    public async Task CaptureSecondQuestionAnswerAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
      //...
    }
