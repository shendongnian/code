    Notifications = new OpenIdConnectAuthenticationNotifications
	{
		RedirectToIdentityProvider = n =>
		{
			// if signing in, send certificate parameters
			if(n.ProtocolMessage.RequestType == OpenIdConnectRequestType.AuthenticationRequest)
			{
				var RequestContext = n.OwinContext.Environment["System.Web.Routing.RequestContext"] as System.Web.Routing.RequestContext;
				if (RequestContext != null)
				{
					var clientCert = RequestContext.HttpContext.Request.ClientCertificate;
					// if client authenticated with certificate then extract certificate info and pass it to identity server
					if (!string.IsNullOrEmpty(clientCert.SerialNumber))
					{
						var sn = clientCert.SerialNumber.Replace("-", "");
						
						// Acr on IdentityServer side explodes by spaces. To prevent splitting values with spaces made some replaces
						n.ProtocolMessage.AcrValues = "cert:" + sn + " " + clientCert.Subject.Replace(" ","_*_").Replace(",_*_"," ");
					}
				}
			}
			return Task.FromResult(0);
		},
	}
