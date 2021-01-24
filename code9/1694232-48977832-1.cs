    context.Wait(WaitForAddressInput);
            }
    
            private async Task WaitForAddressInput(IDialogContext context,
                                          IAwaitable<IActivity> result)
            {
                var message = await result;
                switch (message.Type)
                {
                    case ActivityTypes.Message:
                        //TODO: Add response
                        break;
    
                    case ActivityTypes.Event:
                        //Process event and continue!
                        break;
                }
            }
