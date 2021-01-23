    // Create and cache the plugin context
    this.context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
    var serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
    this.service = serviceFactory.CreateOrganizationService(this.context.UserId);
    // Retrieve the user
    Entity user;
    try
    {
        user = this.service.Retrieve("systemuser", userId, new ColumnSet("domainname"));
    }
    catch (FaultException<OrganizationServiceFault> faultException)
    {
        throw new InvalidPluginExecutionException($"Failed to retrieve domain name of user with Id '{recipient.Id}'", faultException);
    }
    // Get the user's domain name
    string domainName = user.GetAttributeValue<string>("domainname");
