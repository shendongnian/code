    [LuisIntent("qna")]
    public async Task qna(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
    {
        var msg = await activity;
        await context.Forward(new QnADialog(), ResumeAfterQnA, context.Activity, CancellationToken.None);
        await this.ShowLuisResult(context, result);
    }
    
    private async Task ResumeAfterQnA(IDialogContext context, IAwaitable<object> result)
            {
                context.Done<object>(null);
            }
        private async Task ShowLuisResult(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached {result.Intents[0].Intent}. You said: {result.Query}");
            context.Wait(MessageReceived);
        }
