        [Test]
        [TestCase(ContactRelationUpdateActionTypes.Add, true)]
        [TestCase(ContactRelationUpdateActionTypes.Add, false)]
        [TestCase(ContactRelationUpdateActionTypes.Remove, false)]
        public async Task CheckOnContactRelationUpdate(string actionType, bool isBrandNewUser)
        {
            // Mock dB here
            var activityMessageId = Guid.NewGuid().ToString();
            const string userName = "{Some name}";
            const string userId = "{A real user id for your bot}";
            const string serviceUrl = "https://smba.trafficmanager.net/apis/";
            const string channelId = "skype";
            var activity = new Activity
            {
                Id = activityMessageId,
                Type = ActivityTypes.ContactRelationUpdate,
                Action = ContactRelationUpdateActionTypes.Add,
                From = new ChannelAccount(userId, userName),
                Recipient = new ChannelAccount(AppConstants.BotId, AppConstants.BotName),
                ServiceUrl = serviceUrl,
                ChannelId = channelId,
                Conversation = new ConversationAccount {Id = userId},
                Attachments = Array.Empty<Attachment>(),
                Entities = Array.Empty<Entity>()
            };
            var connectorClient = new TestConnectorClient(new Uri(activity.ServiceUrl));
            connectorClient.MockedConversations = new TestConversations(connectorClient);
            var messagesController = new MessagesController(mongoDatabase.Object, connectorClient)
            {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage()
            };
            // Act
            var response = await messagesController.Post(activity);
            var responseMessage = await response.Content.ReadAsStringAsync();
            // Assert
            switch (actionType)
            {
                case ContactRelationUpdateActionTypes.Add:
                    Assert.IsNotEmpty(responseMessage);
                    break;
                case ContactRelationUpdateActionTypes.Remove:
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                    break;
            }
        }
