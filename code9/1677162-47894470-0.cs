     public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("VehiDataCollector","Default", "{controller}.ashx/{action}",
                                     new[] { "Christoc.Modules.VehiDataCollector.Services" });
            //mapRouteManager.MapHttpRoute("MyServices", "default", "{controller}/{action}", new {"MyServices"});
        }
