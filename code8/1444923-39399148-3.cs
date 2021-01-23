        public static void RegisterRoutes(RouteCollection routes)
        {
          routes.MapRoute(
              name: "Articles",
              url: "{date}/{id}",
              defaults: new { controller = "Articles", action = "Info"});
    
          routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
       public class ArticleController : Controller {
        
            public ActionResult Info(string date, int id){
           
                return View();
                
            } 
        }
