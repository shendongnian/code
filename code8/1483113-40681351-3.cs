    public class ExternalDataFactory
    {
       private readonly ITenantLogic _tenantLogic;
       public ExternalDataFactory(ITenantLogic tenantLogic)
       {
           if(tenantLogic == null) throw new ArgumentNullException("tenantLogic");
           _tenantLogic = tenantLogic;
       }
           
       public async Task<IBackendDataConnector> CreateDataHandlerAsync(string tenantId)
            {
                var tenant = await _tenantLogic.GetTenantByIdAsync(tenantId);  
                var settings = tenant.Settings;
        
                if (settings == null)
                    throw new ArgumentException("Specified tenant  has no settings defined");
                
                switch (settings.EnvironmentType)
                {
                    case Constants.EnvironmentType.ExampleA:
                        return new DataHandlerClass(settings);
                    case Constants.EnvironmentType.ExampleB:
                        throw new NotImplementedException();
                    default:
                        throw new Exception("Invalid EnvironmentType");
                };
            }
        }
