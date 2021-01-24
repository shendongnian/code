    [LuisIntent("Help")]
    public async Task Help(IDialogContext context, LuisResult result)
    { 
       context.Call(new CarouselCardsDialog(), DialogsCompleted);
    }
