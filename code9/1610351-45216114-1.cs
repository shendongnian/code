    // getting the OWIN context from the OWIN context parameter
    var owinContext = context.OwinContext;
    var lifetimeScope = owinContext.GetAutofacLifetimeScope(); 
    var siteContext = lifetimeScope.GetService<ISiteContext>();
    context.ProtocolMessage.ClientId = siteContext.ClientId;
