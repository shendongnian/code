    // Make Tenant and TenantContext injectable
    services.AddScoped(prov => 
        prov.GetService<IHttpContextAccessor>()?.HttpContext?.GetTenant<TTenant>());
    services.AddScoped(prov =>
        prov.GetService<IHttpContextAccessor>()?.HttpContext?.GetTenantContext<TTenant>());
