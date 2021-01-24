    string siteUrl = "https://xyz.sharepoint.com/sites/MyList/";
    string clientId = "<client-id>";
    string clientSecret = "<client-secret>";
    
    using (var clientContext = new AuthenticationManager().GetAppOnlyAuthenticatedContext(siteUrl,clientId,clientSecret))
    {		
    	Web oWebsite = clientContext.Web;
    	ListCollection collList = oWebsite.Lists;
    	clientContext.Load(collList);
    	clientContext.ExecuteQuery();
    }
