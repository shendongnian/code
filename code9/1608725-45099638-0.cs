        public async Task<HttpResponseMessage> PostClause(ClauseRequest clauseRequest)
        {
            try
            {
                var channelId = "19:cf4306bb3aff4996.......@thread.skype";
                var serviceURL = "https://smba.trafficmanager.net/apac-client-ss.msg/";
                var connector = new ConnectorClient(new Uri(serviceURL));
                var channelData = new Dictionary<string, string>();
                channelData["teamsChannelId"] = channelId;
                IMessageActivity newMessage = Activity.CreateMessageActivity();
                newMessage.Type = ActivityTypes.Message;
                var good = new CardAction("invoke", "Good", null, "{\"invokeValue\": \"Good\"}");
                var bad = new CardAction("invoke", "Bad", null, "{\"invokeValue\": \"Bad\"}");
                var card = new HeroCard("How are you today?", null, null, null, new List<CardAction> { good, bad }).ToAttachment();
                newMessage.Attachments.Add(card);
                ConversationParameters conversationParams = new ConversationParameters(
                    isGroup: true,
                    bot: null,
                    members: null,
                    topicName: "Test Conversation",
                    activity: (Activity)newMessage,
                    channelData: channelData);
                MicrosoftAppCredentials.TrustServiceUrl(serviceURL, DateTime.MaxValue);
                await connector.Conversations.CreateConversationAsync(conversationParams);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
