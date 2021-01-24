    var connectionString = @"AuthType=Office365;Url=https://REAL.crm.dynamics.com;Username=USERNAME;Password=PASSWORD;RequireNewInstance=True;";
    var connectionString2 = @"AuthType=Office365;Url=https://FAKE.crm.dynamics.com;Username=USERNAME;Password=PASSWORD;RequireNewInstance=True;";	
            
    using (var crmSvcClient = new CrmServiceClient(connectionString))
    {
        "crmSvcClient".Dump();
        crmSvcClient.LastCrmError.Dump();
        ((WhoAmIResponse)crmSvcClient.Execute(new WhoAmIRequest())).OrganizationId.Dump();
        crmSvcClient.ConnectedOrgFriendlyName.Dump();
        
        
    }
    using (var crmSvcClient2 = new CrmServiceClient(connectionString2))
    {
        "crmSvcClient2".Dump();
        crmSvcClient2.LastCrmError.Dump();
        ((WhoAmIResponse)crmSvcClient2.Execute(new WhoAmIRequest())).OrganizationId.Dump();
        crmSvcClient2.ConnectedOrgFriendlyName.Dump();
    }
