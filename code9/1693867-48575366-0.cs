    [Serializable]
    public class PhotoInputDialog : IDialog<string>
    {
        public ICustomInputValidator<IMessageActivity> Validator { get; private set; }
        public string InputPrompt { get; private set; }
        public string WrongInputPrompt { get; private set; }
        public static PhotoInputDialog Create
            (string inputPrompt, string wrongInputPrompt, ICustomInputValidator<IMessageActivity> validator)
        {
            return new PhotoInputDialog()
            { InputPrompt = inputPrompt, WrongInputPrompt = wrongInputPrompt, Validator = validator };
        }
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync(InputPrompt);
            context.Wait(InputGiven);
        }
        private async Task InputGiven(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            if (!Validator.IsValid(message))
            {
                await context.PostAsync(WrongInputPrompt);
                context.Wait(InputGiven);
            }
            else
                context.Done(message.Attachments.First().ContentUrl);
        }
    }
