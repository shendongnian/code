    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            // DEMO PURPOSE: echo all incoming activities
            Activity reply = activity.CreateReply(Newtonsoft.Json.JsonConvert.SerializeObject(activity, Newtonsoft.Json.Formatting.None));
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            connector.Conversations.SendToConversation(reply);
            // Process each activity
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            }
            // Webchat: getting an "event" activity for our js code
            else if (activity.Type == ActivityTypes.Event && activity.ChannelId == "webchat")
            {
                var receivedEvent = activity.AsEventActivity();
                if ("localeSelectionEvent".Equals(receivedEvent.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    await EchoLocaleAsync(activity, activity.Locale);
                }
            }
            // Sample for emulator, to debug locales
            else if (activity.Type == ActivityTypes.ConversationUpdate && activity.ChannelId == "emulator")
            {
                foreach (var userAdded in activity.MembersAdded)
                {
                    if (userAdded.Id == activity.From.Id)
                    {
                        await EchoLocaleAsync(activity, "fr-FR");
                    }
                }
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
        
        private async Task EchoLocaleAsync(Activity activity, string inputLocale)
        {
            Activity reply = activity.CreateReply($"User locale is {inputLocale}, you should use this language for further treatment");
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            await connector.Conversations.SendToConversationAsync(reply);
        }
    }
