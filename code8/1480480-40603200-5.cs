    [Serializable]
    public class Category1Dialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }
        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            
            var prompt = "what is the answer to question 1 ?";
            //ASK QUESTION 1
            PromptDialog.Text(context, ResumeAfterQuestion1, prompt);
        }
        private async Task ResumeAfterQuestion1(IDialogContext context, IAwaitable<string> result)
        {
            var input = await result;
            switch (input)
            {
                //ASK QUESTION 2, DEPENDING ON WHAT WAS ANSWERED FOR QUESTION 1
                case "Answer A":
                    PromptDialog.Text(context, ResumeAfterQuestion2, "what is the answer to question 2 ?");
                    break;
                case "Answer B":
                    PromptDialog.Text(context, ResumeAfterQuestion2, "what is the answer to question 2 ?");
                    break;
            }
        }
        private async Task ResumeAfterQuestion2(IDialogContext context, IAwaitable<string> result)
        {
            var input = await result;
            switch (input)
            {
                //ASK QUESTION 3
                case "Answer C":
                    PromptDialog.Text(context, ResumeAfterQuestion3, "what is the answer to next question after Answer C ?");
            break;
                case "Answer D":
                    PromptDialog.Text(context, ResumeAfterQuestion3, "what is the answer to next question after Answer D ?");
            break;
        }
        }
