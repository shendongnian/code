        [LuisIntent("")]
        public async Task None(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            await context.PostAsync("I have no idea what you are talking about.");
            context.Wait(MessageReceived);
        }
