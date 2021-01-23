    public async Task<HttpResponseMessage> Post([FromBody] Activity activity)
    {
        if (activity.Type == ActivityTypes.Message)
        {
            if (activity.ChannelId === "slack") {
                if (activity.Text.ToLower().StartsWith("@myCustomBot") {
                    return Request.CreateResponse(HttpStatusCode.OK); //quit
                }
            }
            else if (activity.ChannelId === "facebook") {
                //similar check, and if true, then:
                    //return Request.CreateResponse(HttpStatusCode.OK);
            }
    
            //otherwise, keep going:
    
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
    
            connector.Conversations.ReplyToActivityAsync(activity.CreateReply("hi there"));
            //...
        }
        //...
    }
