	public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
	{
		var reply = context.MakeMessage();
		reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
		reply.Attachments = GetCardsAttachments();
		await context.PostAsync(reply);
		context.Wait(this.MessageReceivedAsync);
	}
