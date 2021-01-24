    [Serializable]
    public class HelpDialog : IDialog
    {
         public async Task StartAsync(IDialogContext context)
        {
            PromptDialog.Choice<string>(context, TopicSelectedAsync, HelpTopicSelector.Instance.Topics, "Select A Topic:", attempts: 3, retry: "Please select a Topic");
        }
        
        private async Task TopicSelectedAsync(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                string selection = await result as string;
    
                if (HelpTopicSelector.Instance.IsQuestionNode(selection))
                {
                    await context.PostAsync($"You asked: {selection}");
                    HelpTopicSelector.Instance.Reset();
                    context.Done<string>(selection);
                }
                else
                {
                    await this.StartAsync(context);
                }
            }
            catch (TooManyAttemptsException)
            {
                await this.StartAsync(context);
            }                
        }
    }
