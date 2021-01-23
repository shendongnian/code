    using Microsoft.Xrm.Sdk;
    
    using Microsoft.Xrm.Sdk.Client;
        #region GetOrganizationService
    public static IOrganizationService GetOrganizationService()
    {
      try
      {
        IOrganizationService organizationService = null;
        Uri uri = new Uri("OrganizationUri");
        var credentials = new ClientCredentials();
        credentials.UserName.UserName = "UserName";
        credentials.UserName.Password = "Password";
        // Cast the proxy client to the IOrganizationService interface.
        using (OrganizationServiceProxy organizationServiceProxy = new OrganizationServiceProxy(uri, null, credentials, null))
        { organizationService = (IOrganizationService)organizationServiceProxy; }
        return organizationService;
      }
      catch (System.Exception exception)
      {
        throw exception;
      }
    }
    #endregion
