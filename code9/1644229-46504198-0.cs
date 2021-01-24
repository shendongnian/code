    IApplicationEventHandler.OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
          RouteTable.Routes.MapRoute("NameTheRoute", "{controller}/{action}/{id}",
                                     new { 
                                           controller = "YourController",
                                           action = "YourAction", 
                                           id = UrlParameter.Optional
                                         });
        }
