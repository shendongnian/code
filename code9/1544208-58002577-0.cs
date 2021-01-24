csharp
public class ApplicationEventHandler : IApplicationEventHandler
{
    public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
        RegisterCustomRoutes();
    }
    private static void RegisterCustomRoutes()
    {
        // this is just an example, modify to suit your controllers and actions
        System.Web.Routing.RouteTable.Routes.MapRoute(
           name: "WhateverController",
           url: "Whatever/{action}/{id}",
           defaults: new { controller = "Whatever", action = "DoTheThing", id = UrlParameter.Optional });
    }
}
Then `WhateverController.DoTheThing(int id)` should be accessible at /whatever/dothething/1 , as it normally would for MVC.  Unfortunately if you have lots of controllers and actions this will probably be a lot of work to set up and even more to maintain, so you might need to find an easier way to generate these routes in bulk.
