    public interface ITenantLogic
    {    
       Task<Tenant> GetTenantByIdAsync(int tenantId);
    }
    public class TenantLogic: ITenantLogic
    {
       public async Task<Tenant> GetTenantByIdAsync(int tenantId)
       {
          // logic to get the tenant goes here
       }
    }
