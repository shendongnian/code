    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfig = new HttpConfiguration();
            httpConfig.MapHttpAttributeRoutes();
            httpConfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var appXmlType = httpConfig.Formatters.XmlFormatter.SupportedMediaTypes
                                       .FirstOrDefault(t => t.MediaType == "application/xml");
            httpConfig.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            app.UseWebApi(httpConfig);
        }
    }
