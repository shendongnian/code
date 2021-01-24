    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "index", id = UrlParameter.Optional },
                namespaces: new[] { "Company.Project.Web.UI.Areas.Admin.Controllers" }
            );
        }
    }
