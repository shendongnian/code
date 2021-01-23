    public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
    {
        string thisIsTheToken = context.AccessToken;
        //add user Id and status as additional response parameter
        context.AdditionalResponseParameters.Add("displayusername", "Hi Mundo");
        context.AdditionalResponseParameters.Add("Status", "1");     
        return base.TokenEndpointResponse(context);
    }
