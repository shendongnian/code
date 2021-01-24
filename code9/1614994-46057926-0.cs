        [LuisIntent("PerformSearch")]
        public async Task Search(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            var msg = await activity;
            msg.Value = result;
            await context.Forward(new SearchDialog(), ResumeAfterSearchPerformed, msg, CancellationToken.None);
            
        }
