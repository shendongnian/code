    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        if (activity.Type == ActivityTypes.Event &&
            string.Equals(activity.Name, "buttonClicked", StringComparison.InvariantCultureIgnoreCase))
        {
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
    
            // return our reply to the user
            Activity reply = activity.CreateReply("I see that you just pushed that button");
            await connector.Conversations.ReplyToActivityAsync(reply);
        }
    
        if (activity.Type == ActivityTypes.Message)
        {
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
    
            // return our reply to the user
            var reply = activity.CreateReply();
            reply.Type = ActivityTypes.Event;
            reply.Name = "changeBackground";
            reply.Value = activity.Text;
            await connector.Conversations.ReplyToActivityAsync(reply);
        }
        else
        {
            HandleSystemMessage(activity);
        }
        var response = Request.CreateResponse(HttpStatusCode.OK);
        return response;
    }
