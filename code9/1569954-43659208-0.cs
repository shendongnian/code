    internal class TenantFullProjector : IProjector<Tenant, TenantProjection>
    {
        public Expression<Func<Tenant, TenantProjection>> GetProjection()
        {
            return (x) => new TenantProjection()
            {
                Code = x.Code,
                DatabaseId = x.DatabaseId,
                Id = x.Id,               
            };
        }
    }
