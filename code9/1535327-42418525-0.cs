    public async Task Confirmed(IDialogContext context, IAwaitable<bool> argument)
        {
            bool isCorrect = await argument;
            if (isCorrect)
            { }
            else
            { }
        }
