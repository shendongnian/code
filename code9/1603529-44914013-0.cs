    [LuisIntent("Stores")]
    public async Task Stores(IDialogContext context, LuisResult result)
    {
        var defaultRadius = 10;
        await SearchInArea(context, defaultRadius);
    }
    private async Task SearchInArea(IDialogContext context, int radius)
    {
        var reply = context.MakeMessage();
        reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
        reply.Attachments = new List<Attachment>();
        List<CardImage> images = new List<CardImage>();
        InfoClass IC = new InfoClass();
        latitude = "-29.794618";
        longitude = "30.823497";
        LocationObject[] StoreLocations = IC.NearBy(latitude, longitude, radius, context);
        int count = StoreLocations.Length;
        for (int z = 0; z < count; z++)
        {
            CardImage Ci = new CardImage("https://maps.googleapis.com/maps/api/staticmap?size=764x400&center=" + StoreLocations[z].Latitude + "," + StoreLocations[z].Longitude + "&zoom=15&markers=" + StoreLocations[z].Latitude + "," + StoreLocations[z].Longitude);
            images.Add(Ci);
            HeroCard hc = new HeroCard()
            {
                Title = StoreLocations[z].StoreName,
                Subtitle = StoreLocations[z].Subtitle,
                Images = new List<CardImage> { images[z] },
                Buttons = new List<CardAction>()
            };
            CardAction ca = new CardAction()
            {
                Title = "Show Me",
                Type = "openUrl",
                Value = "https://www.google.co.za/maps/search/" + StoreLocations[z].Latitude + "," + StoreLocations[z].Longitude
            };
            hc.Buttons.Add(ca);
            reply.Attachments.Add(hc.ToAttachment());
        }
        await context.PostAsync(reply);
        PromptDialog.Confirm(context, PromptDecision, "Would You Like To Change The Search Radius ?", attempts: 100);
    }
    private async Task PromptDecision(IDialogContext context, IAwaitable<bool> userInput)
    {
        var userBoolChoice = await userInput;
        if (userBoolChoice)
        {
            RadiusPromt(context);
        }
        else
        {
            StartUp(context, null).Start();
        }
    }
    private void RadiusPromt(IDialogContext context)
    {
        PromptDialog.Number(context, AfterPromptMethod, "Please Enter Search Radius (In Kilometers)", attempts: 100);
    }
    private async Task AfterPromptMethod(IDialogContext context, IAwaitable<long> userInput)
    {
        int radius = Convert.ToInt32(await userInput);
        await SearchInArea(context, radius);
    }
