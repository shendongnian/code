    public class AreaBAreaRegistration : AreaRegistration 
    { 
        public override string AreaName 
        { 
            get { return "AreaB"; } 
        } 
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreaB_Getdata",
                "AreaB/Home/Getdata",
                new { controller = "Home", action = "GetData" },
                new string[] { "areastest.Areas.AreaGeneral.Controllers" }).DataTokens["area"] = "AreaGeneral";
            context.MapRoute(
                "AreaB_default", 
                "AreaB/{controller}/{actio‌​n}/{id}", 
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
