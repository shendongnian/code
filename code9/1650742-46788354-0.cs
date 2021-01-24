    public static SecurityToken GetToken(string userName, string password)
    {
    	const string stsEndpoint = "https://localhost:9443/services/wso2carbon-sts";
    	const string realm = "http://localhost/myApp";
    
    	var factory = new WSTrustChannelFactory(
    		new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential),
    		stsEndpoint) { TrustVersion = TrustVersion.WSTrust13 };
    
    	factory.Credentials.UserName.UserName = userName;
    	factory.Credentials.UserName.Password = password;
    
    	var rst = new RequestSecurityToken
    	{
    		AppliesTo = new EndpointReference(realm),
    		RequestType = RequestTypes.Issue,
    		KeyType = KeyTypes.Bearer
    	};
    
    	var channel = factory.CreateChannel();
    	var token = channel.Issue(rst);
    	return token;
    }
