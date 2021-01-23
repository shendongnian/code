	OnRedirectToIdentityProvider = n =>
	{
		if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.Authentication)
		{    
			n.ProtocolMessage.Prompt = "login";
		}
		return Task.FromResult(0);
	}
