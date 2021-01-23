    public Interface ITenantDiscovery
    {
      int TenantId{get;}
    }
    public class UrlTenantDiscovery:ITenantDiscovery
    {
     public int TenantId
     {
       get
        {
           var url = -- get current URL, ex: from HttpContext
           var tenant = _context.Tenants.Where(a=>a.Url == url);
           return tenant.Id; -- cache the Id for subsequent calls
        }
     }
