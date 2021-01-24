    private async Task CallDialog(IDialogContext context, IAwaitable<string> result)
    {
        //These two variables will be exactly the same, you only need one     
        //var selectedMenu = await result;
        var message = await result;
        switch (selectedMenu)
        {
            case EnglishMenu:
                // Forward the context to the new LuisDialog to bring it to the top of the stack.  
                // This will also send your message to it so it gets processed there.
                await context.Forward<object>(new EnglishLuis(), ResumeAfterDialog, message , CancellationToken.None);
                break;
            case FrenchMenu:
                 await context.Forward<object>(new HotelDialog(location), ResumeAfterDialog, message , CancellationToken.None);
                break;
            case QAMenu:
                 await context.Forward<object>(new LuisCallDialog(), ResumeAfterDialog, message , CancellationToken.None);
                context.Call(new LuisCallDialog(),ResumeAfterDialog);
                break;
        }
    }
