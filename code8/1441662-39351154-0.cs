    /* attributes removed */
    public class LandingPageController : ApiController
    {
        public IHttpActionResult GetQuadrantData(string unit, string begdate, string enddate)
        {
            ...
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            /* Route added before the default one */
            config.Routes.MapHttpRoute(
                name: "QuadrantData",
                routeTemplate: "api/{unit}/{begdate}/{enddate}"
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
