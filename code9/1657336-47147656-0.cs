        private async Task OnOptionSelected(IDialogContext context, IAwaitable<int> result)
        {
            try
            {
    
                int optionSelected = await result;
                var foundOption = Option.CreateListOption().First(o => o.ID == optionSelected);
    //do more with foundOption
                switch (optionSelected)
                {
                    case 1:
                        context.Call(new RootDialog(), this.ResumeAfterChoose);
                        break;
                    default: { context.Wait(MessageReceivedAsync); break; }
                }
            }
            catch (TooManyAttemptsException ex)
            {
                await context.PostAsync($"Ooops! Too many attemps :(. But don't worry, I'm handling that exception and you can try again!");
    
                context.Wait(this.MessageReceivedAsync);
            }
        }
