    //Answer
    if(activity.From.Name != null)
    string userName= activity.From.Name;
    
    //Example
    
    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
    	if (activity.Type == ActivityTypes.Message)
    	{
    	string userName= "";
    	if(activity.From.Name != null)
    	userName= activity.From.Name;//Here we are getting user name
    	ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
    	Activity reply = activity.CreateReply(userName);
    	activity.TextFormat = "markdown";
    	await connector.Conversations.ReplyToActivityAsync(reply);
    
    	}
    	else
    	{
    	HandleSystemMessage(activity);
    	}
    	var response = Request.CreateResponse(HttpStatusCode.OK);
    	return response;
    }
