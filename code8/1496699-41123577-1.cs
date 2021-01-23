    using System.Web.Http;
    using System.Web.Routing;
 
     protected void Application_Start(Object sender, EventArgs e)
            {
                RouteTable.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = System.Web.Http.RouteParameter.Optional }
                    );
            }
