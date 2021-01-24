        [LuisIntent("None")]
        public async Task None(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            var luisService = new LuisService(new LuisModelAttribute("XXX", "XXX"));
            await context.Forward(new MyChildDialog(luisService), WaitForMessageResume, await message);
            context.Wait(MessageReceived);
        }
        private Task WaitForMessageResume(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
            return Task.CompletedTask;
        }
