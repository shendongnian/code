    public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument) 
    {
       var dialog = new PromptDialog.PromptString("Please enter a parameter", "please try again", 2);
        
       context.Call(dialog, ResumeAfterPrompt)
    }
    private Task ResumeAfterPrompt(IDialogContext context, IAwaitable<string> result)
    {
        var parameter = await result;
        context.Done(parameter);
    }
                
  
   
