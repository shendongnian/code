    public abstract class TenantDbContext : DbContext
    {
    	protected ITenantProvider TenantProvider;
    	internal int TenantId => TenantProvider.GetId();
    }
