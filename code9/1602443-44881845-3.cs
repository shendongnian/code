    [Serializable]
    public class MyFacebookLocationDialog : IDialog<Place>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }
        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var msg = await argument;
            // Here we prepare the message on Facebook that will ask for Location
            if (msg.ChannelId == "facebook")
            {
                var reply = context.MakeMessage();
                reply.ChannelData = new FacebookMessage
                (
                    text: "Please share your location with me.",
                    quickReplies: new List<FacebookQuickReply>
                    {
                        // If content_type is location, title and payload are not used
                        // see https://developers.facebook.com/docs/messenger-platform/send-api-reference/quick-replies#fields
                        // for more information.
                        new FacebookQuickReply(
                            contentType: FacebookQuickReply.ContentTypes.Location,
                            title: default(string),
                            payload: default(string)
                        )
                    }
                );
                await context.PostAsync(reply);
                // LocationReceivedAsync will be the place where we handle the result
                context.Wait(LocationReceivedAsync);
            }
            else
            {
                context.Done(default(Place));
            }
        }
        public async Task LocationReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var msg = await argument;
            var location = msg.Entities?.Where(t => t.Type == "Place").Select(t => t.GetAs<Place>()).FirstOrDefault();
            // Printing message main content about location
            await context.PostAsync($"Location received: { Newtonsoft.Json.JsonConvert.SerializeObject(msg.Entities) }");
        
            // The result can be used then to do what you want, here in this sample it outputs a message with a link to Bing Maps centered on the position
            var geo = (location.Geo as JObject)?.ToObject<GeoCoordinates>();
            if (geo != null)
            {
                var reply = context.MakeMessage();
                reply.Attachments.Add(new HeroCard
                {
                    Title = "Open your location in bing maps!",
                    Buttons = new List<CardAction> {
                                new CardAction
                                {
                                    Title = "Your location",
                                    Type = ActionTypes.OpenUrl,
                                    Value = $"https://www.bing.com/maps/?v=2&cp={geo.Latitude}~{geo.Longitude}&lvl=16&dir=0&sty=c&sp=point.{geo.Latitude}_{geo.Longitude}_You%20are%20here&ignoreoptin=1"
                                }
                            }
                }.ToAttachment());
                await context.PostAsync(reply);
                context.Done(location);
            }
            else
            {
                await context.PostAsync("No GeoCoordinates!");
                context.Done(default(Place));
            }
        }
    }
