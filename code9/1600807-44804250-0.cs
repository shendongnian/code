    public class RequestSubdomainStrategy : IDeskfulTenantIdentificationStrategy
    {
        private ITenant _tenant;
        public ITenant Tenant
        {
            get
            {
                return _tenant;
            }
            private set
            {
                _tenant = value;
            }
        }
        public bool TryIdentifyTenant(out object tenantId)
        {
            tenantId = null;
            try
            {
                var context = HttpContext.Current;
                if (context != null && context.Request != null)
                {
                    var site = context.Request.Url.Host;
                    Tenant = new Tenant("tenant1.deskfull.be", "connString", "Tenant 1") { Id = 20 };
                    tenantId = Tenant.Id;
                }
            }
            catch { }
            return tenantId != null;
        }
    }
