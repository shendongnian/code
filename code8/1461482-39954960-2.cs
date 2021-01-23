    // Create and cache the plugin context
    this.context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
    var serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
    this.service = serviceFactory.CreateOrganizationService(this.context.UserId);
    // Retrieve users with certain ID
    Guid userId = Guid.NewGuid();
    var query = new QueryExpression("systemuser");
    query.Criteria.AddCondition(new ConditionExpression("systemuserid", ConditionOperator.Equal, userId));
    EntityCollection users;
    try
    {
        users = this.service.RetrieveMultiple(query);
    }
    catch (FaultException<OrganizationServiceFault> faultException)
    {
        throw new InvalidPluginExecutionException($"Failed to retrieve system users", faultException);
    }
    if (users.Entities.Length == 0) // (or !users.Entities.Any() using Linq)
    {
        // Do something
    }
