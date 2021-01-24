    using System.Web.Http;
    using System.Web.OData.Extensions;
    using System.Web.OData.Builder;
    //using System.Web.OData.Extensions;
    using wcod.Model;
    
    namespace wcod
    {
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                // Web API configuration and services
                ODataModelBuilder builder = new ODataConventionModelBuilder();
                config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
    
                builder.EntitySet<TimeMarker>("TimeMarkers");
    
                var function = builder.Function("GetTimeMarkerSearch");
                function.Parameter<string>("bookID");
                function.Parameter<string>("keywords");
                function.ReturnsCollectionFromEntitySet<TimeMarker>("TimeMarkers");
                    config.MapHttpAttributeRoutes();
          
                //config.Routes.MapODataServiceRoute("odata", "odata/v4", builder.GetEdmModel());
                
                config.MapODataServiceRoute("odata", "odata/v4", builder.GetEdmModel());
            }
    
        }
    }
