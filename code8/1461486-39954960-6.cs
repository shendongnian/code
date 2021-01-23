    using (OrganizationServiceProxy serviceProxy = new OrganizationServiceProxy(OrganizationUri, HomeRealmUri, credentials, null))
    {
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
           throw new InvalidPluginExecutionException($"Failed to retrieve system users that have an ID of '{userId}'", faultException);
       }
       if (users.Entities.Length == 0) // (or !users.Entities.Any() using Linq)
       {
           // Do something
       }
    }
