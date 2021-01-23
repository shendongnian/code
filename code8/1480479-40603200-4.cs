    [LuisIntent("AskQuestionAboutCategory")]
        public async Task AskQuestion(IDialogContext context, LuisResult result)
        {
           //get Entity from LUIS response
            string category = result.Entities.FirstOrDefault(e => e.Type == "Category")?.Entity;
            switch (category)
            {
                case "Category 1":
                    //forward to Dialog for Category1
                    await
                        context.Forward(new Category1Dialog(), ResumeAfter,
                            new Activity {Text = result.Query}, CancellationToken.None);
                    break;
                case "Category 2":
                    //forward to Dialog for Category2
                    await
                        context.Forward(new Category2Dialog(), ResumeAfter,
                            new Activity {Text = result.Query}, CancellationToken.None);
                    break;
            }
        }
        private async Task ResumeAfter(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }
