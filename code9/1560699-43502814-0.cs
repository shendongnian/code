    DirectLineClientCredentials creds = new DirectLineClientCredentials(directLineSecret);
    DirectLineClient directLineClient = new DirectLineClient(creds);
    Conversation conversation = await directLineClient.Conversations.StartConversationAsync();
    
    using (var webSocketClient = new WebSocket(conversation.StreamUrl))
    {
        webSocketClient.OnMessage += WebSocketClient_OnMessage;
        webSocketClient.Connect();
        while (true)
    
        {
            string input = Console.ReadLine().Trim();
    
            if (input.ToLower() == "exit")
            {
                break;
            }
            else
            {
                if (input.Length > 0)
                {
                    Activity userMessage = new Activity
                    {
                        From = new ChannelAccount(fromUser),
                        Text = input,
                        Type = ActivityTypes.Message
                    };
    
                    await directLineClient.Conversations.PostActivityAsync(conversation.ConversationId, userMessage);
                }
            }
        }
    }
    private static void WebSocketClient_OnMessage(object sender, MessageEventArgs e)
    {
        // avoid null reference exception when no data received
        if (string.IsNullOrWhiteSpace(e.Data))
        {
            return;
        }
    
        var activitySet = JsonConvert.DeserializeObject<ActivitySet>(e.Data);
        var activities = from x in activitySet.Activities
                            where x.From.Id == botId
                            select x;
    
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.Text);
        }
    }
