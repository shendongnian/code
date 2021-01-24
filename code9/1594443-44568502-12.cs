    [BotAuthentication(CredentialProviderType = typeof(MultiCredentialProvider))]
    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        if (activity.Type == ActivityTypes.Message)
        { 
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            Activity reply = activity.CreateReply("it Works!");                       
            await connector.Conversations.ReplyToActivityAsync(reply);
        }
    }
