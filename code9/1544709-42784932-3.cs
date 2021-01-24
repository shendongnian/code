    try
    {
        var userAccount = new ChannelAccount() { Id = "default-user", Name = "user" };
        var botAccount = new ChannelAccount() { Id = "934493jn5f6f348f", Name = "console-Bot" };
        string url = "{serviceUrl}";
        MicrosoftAppCredentials.TrustServiceUrl(url, DateTime.Now.AddDays(7));
        var account = new MicrosoftAppCredentials("{MicrosoftAppIdKey}", "{MicrosoftAppPasswordKey}");
        var connector = new ConnectorClient(new Uri(url), account);
        IMessageActivity message = Activity.CreateMessageActivity();
        message.From = botAccount;
        message.Recipient = userAccount;
        message.Conversation = new ConversationAccount() { Id = "{conversationId}" };
        message.Text = "Message sent from console application!!!";
        message.Locale = "en-us";
        var response = await connector.Conversations.SendToConversationAsync((Activity)message);
        Console.WriteLine($"response:{response.Id}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"exception:{e.Message}\r\n{e.StackTrace}");
    }
