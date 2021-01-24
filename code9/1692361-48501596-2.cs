    [LuisIntent("Help")]
    public async Task Help(IDialogContext context, LuisResult result)
    { 
    	//context.Call(new CarouselCardsDialog(), DialogsCompleted);
    	await context.Forward(new CarouselCardsDialog(), DialogsCompleted, context.Activity.AsMessageActivity(), CancellationToken.None);
    }
