    public class TradeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
            {
                get 
                {
                    return "Trade";
                }
            }
    
        public override void RegisterArea(AreaRegistrationContext context) 
        {    
            context.MapRoute(
             name: "MyOldToMyNew",
             url: "Trade/MyOld",
             defaults: new { controller = "MyNew", action = "Index", id = UrlParameter.Optional }
         );
    
            context.MapRoute(
                name: "Trade_default",
                url: "Trade/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
