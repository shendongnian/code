    var tenantLogic = new TenantLogic();
    var tenant = await tenantLogic.GetTenantByIdAsync(tenantId); 
    var factory = new ExternalDataFactory();
    IBackendDataConnector dataConnector =
            factory.CreateDataHandler(tenant.Settings);
    return await dataConnector.DoSomethingAsync(tenant.Settings);
