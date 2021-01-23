    public class AppTenantResolver : ITenantResolver<AppTenant>
    {
        IEnumerable<AppTenant> tenants = new List<AppTenant>(new[]
        {
            new AppTenant {
                Name = "Tenant 1",
                Hostnames = new[] { "localhost:6000", "localhost:6001" }
            },
            new AppTenant {
                Name = "Tenant 2",
                Hostnames = new[] { "localhost:6002" }
            }
        });
    
        public async Task<TenantContext<AppTenant>> ResolveAsync(HttpContext context)
        {
            TenantContext<AppTenant> tenantContext = null;
            // it's just a sample...
            var tenant = tenants.FirstOrDefault(t =>
                t.Hostnames.Any(h => h.Equals(context.Request.Host.Value.ToLower())));
    
            if (tenant != null)
            {
                tenantContext = new TenantContext<AppTenant>(tenant);
            }
    
            return tenantContext;
        }
    }
