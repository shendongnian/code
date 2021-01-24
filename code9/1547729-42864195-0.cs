    private async Task RequestEmailAddress(IDialogContext context, IAwaitable<IMessageActivity> result)
    {
        var message = await result;
        var thumbNailCard = new ThumbnailCard
        {
            Title = "BotFramework Thumbnail Card",
            Subtitle = "Your bots — wherever your users are talking",
            Text = "Build and connect intelligent bots to interact with your users naturally wherever they are, from text/sms to Skype, Slack, Office 365 mail and other popular services.",
            Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
            Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.botframework.com/en-us/") }
        };
    
        var resultMessage = context.MakeMessage();
        resultMessage.AttachmentLayout = AttachmentLayoutTypes.Carousel;
        resultMessage.Attachments = new List<Attachment> { thumbNailCard.ToAttachment() };
        await context.PostAsync(resultMessage);
        context.Wait(RequestEmailAddress);
    }
