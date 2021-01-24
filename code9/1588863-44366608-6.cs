    if (activity.MembersAdded.Count != 0)
    {
        // We have to create a new conversation between Bot and AddedUser
        #region Conversation creation
        // Connector init
        MicrosoftAppCredentials.TrustServiceUrl(activity.ServiceUrl, DateTime.Now.AddDays(7));
        var account = new MicrosoftAppCredentials("yourMsAppId", "yourMsAppPassword");
        var connector = new ConnectorClient(new Uri(activity.ServiceUrl), account);
        // From the conversationUpdate message, Recipient = bot and From = User
        ChannelAccount botChannelAccount = new ChannelAccount(activity.Recipient.Id, activity.Recipient.Name);
        ChannelAccount userChannelAccount = new ChannelAccount(activity.From.Id, activity.From.Name);
        // Create Conversation
        var conversation = await connector.Conversations.CreateDirectConversationAsync(botChannelAccount, userChannelAccount);
        #endregion
        // Then we prepare a fake message from bot to user, mandatory to get the working IDialogTask. This message MUST be from User to Bot, if you want the following Dialog to be from Bot to User
        IMessageActivity fakeMessage = Activity.CreateMessageActivity();
        fakeMessage.From = userChannelAccount;
        fakeMessage.Recipient = botChannelAccount;
        fakeMessage.ChannelId = activity.ChannelId;
        fakeMessage.Conversation = new ConversationAccount(id: conversation.Id);
        fakeMessage.ServiceUrl = activity.ServiceUrl;
        fakeMessage.Id = Guid.NewGuid().ToString();
        // Then use this fake message to launch the new dialog
        using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, fakeMessage))
        {
            var botData = scope.Resolve<IBotData>();
            await botData.LoadAsync(CancellationToken.None);
            //This is our dialog stack
            var task = scope.Resolve<IDialogTask>();
            //interrupt the stack. This means that we're stopping whatever conversation that is currently happening with the user
            //Then adding this stack to run and once it's finished, we will be back to the original conversation
            var dialog = new DemoDialog();
            task.Call(dialog.Void<object, IMessageActivity>(), null);
            await task.PollAsync(CancellationToken.None);
            //flush dialog stack
            await botData.FlushAsync(CancellationToken.None);
        }
    }
