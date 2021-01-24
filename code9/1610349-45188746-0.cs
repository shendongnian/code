	private Task SetSettingsForRequest(RedirectToIdentityProviderNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> context)
	{
		// getting the OWIN context from the OIDC notification context
		var owinContext = context.OwinContext;
		// that's an extension method provided by the Autofac OWIN integration
		// see https://github.com/autofac/Autofac.Owin/blob/1e6eab35b59bc3838bbd2f6c7653d41647649b01/src/Autofac.Integration.Owin/OwinContextExtensions.cs#L19
		var lifetimeScope = owinContext.GetAutofacLifetimeScope(); 
	    var siteContext = lifetimeScope.GetService<ISiteContext>();
	    context.ProtocolMessage.ClientId = siteContext.ClientId;
	    return Task.FromResult(0);
	}
