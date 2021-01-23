            private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
            {
                try
                {
                    string optionSelected = await result;
    
                    switch (optionSelected)
                    {
                        case FlightsOption:
                            context.Call(new FlightsDialog(), this.ResumeAfterOptionDialog);
                            break;
    
                        case HotelsOption:
                            context.Call(new HotelsDialog(), this.ResumeAfterOptionDialog);
                            break;
                    }
                }
                catch (TooManyAttemptsException ex)
                {
                    await context.PostAsync($"Ooops! Too many attemps :(. But don't worry, I'm handling that exception and you can try again!");
    
                    context.Wait(this.MessageReceivedAsync);
                }
            }
