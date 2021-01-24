    private async Task LocationReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        var reply = context.MakeMessage();
        reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
        reply.Attachments = new List<Attachment>();
        List<CardImage> images = new List<CardImage>();
        InfoClass IC = new InfoClass();
        var msg = await argument;
        var location = msg.Entities?.FirstOrDefault(e => e.Type == "Place");
        if (location != null)
        {
            latitude = location.Properties["geo"]?["latitude"]?.ToString();
            longitude = location.Properties["geo"]?["longitude"]?.ToString();
            LocationObject[] StoreLocations = IC.NearBy(latitude, longitude, Radius, context);
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
            PromptDialog.Confirm(context, PromtDecision, "Would You Like To Change The Search Radius ?", attempts: 100);
        }
        // Change is here
        else
        {
            context.Done(location);
        }
    }
