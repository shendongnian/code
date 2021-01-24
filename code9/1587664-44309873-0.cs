    using System;
    using System.Web.Mvc;
    
    namespace WebApplication1.Areas.SiteSettings
    {
        public class SiteSettingsAreaRegistration : AreaRegistration 
        {
            public override string AreaName 
            {
                get 
                {
                    return "SiteSettings";
                }
            }
    
            public override void RegisterArea(AreaRegistrationContext context)
            {
                context.MapRoute(
                    name: "SiteSettings_Controller",
                    url: "SiteSettings/{controller}/{action}/{id}",
                    defaults: new
                    {
                        action = "Index",
                        id = UrlParameter.Optional
                    },
                constraints: new { controller = "UserManagement|Tools|Settings" }
                );
            }
        }
    }
