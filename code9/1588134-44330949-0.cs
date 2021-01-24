    private async Task ProductChoice(IDialogContext context, IAwaitable<string> result)
        {
    
            PromptDialog.Choice<string>(
            context,
            AfterPromptChoiceMethod,
            this.productOptions,
            "Which plaform are you interested in?",
            "Ooops, what you wrote is not a valid option, please try again",
            3,
            PromptStyle.PerLine);
            await context.PostAsync(context.MakeMessage());
        }        
    
       private async Task AfterPromptChoiceMethod(IDialogContext context, IAwaitable<string> result)
        {
           await ProductOverview(context, null);
        }
