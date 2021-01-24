    public interface ISiteContext
    {
        string Tenant { get; }
    }
    public class SiteContext : ISiteContext
    {
        private const string _routeId = "tenantId";
        private string _tenant;
        public string Tenant {  get { return _tenant; } }
        public SiteContext()
        {
            _tenant = GetTenantViaRoute();
        }
        private string GetTenantViaRoute()
        {
            var routedata = HttpContext.Current.Request.RequestContext.RouteData;
            // Default Routing
            if (routedata.Values[_routeId] != null)
            {
                return routedata.Values[_routeId].ToString().ToLower();
            }
            // Attribute Routing
            if (routedata.Values.ContainsKey("MS_SubRoutes"))
            {
                var msSubRoutes = routedata.Values["MS_SubRoutes"] as IEnumerable<IHttpRouteData>;
                if (msSubRoutes != null && msSubRoutes.Any())
                {
                    var subRoute = msSubRoutes.FirstOrDefault();
                    if (subRoute != null && subRoute.Values.ContainsKey(_routeId))
                    {
                        return (string)subRoute.Values
                            .Where(x => x.Key.Equals(_routeId))
                            .Select(x => x.Value)
                            .Single();
                    }
                }
            }
            return string.Empty;
        }
    }
