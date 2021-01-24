    [Serializable]
    public class CurrentDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var promptOptions = new CancelablePromptOptions<string>(MyDictionary.ChooseOneOfTheFollowingOptions, cancelPrompt: "cancel", options: MyHelper.GetOptions(), promptStyler: PromptStyler);
            CancelablePromptChoice<string>.Choice(context, OptionSelected, promptOptions);
        }
        private async Task OptionSelected(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var option = await result;
                if (option == null)
                {
                    context.Done<string>(null);
                    return;
                }
                // Here is your logic in a "normal" case where an option is selected
                ...
            }
            catch (TooManyAttemptsException)
            {
                // Too many attempts exception management
            }
        }
    }
