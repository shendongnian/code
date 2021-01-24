    public string Index()
    {
        int tenantId = TenantIdStrategy.IdentifyTenant<int>();
        return "Home - Index: " + TenantIdStrategy.Tenant.TenantName;
    }
