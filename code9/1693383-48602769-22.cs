    public class Domain2AreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Domain2";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Domain2_default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }, 
                constraints: new { _ = DomainConstraint("www.domain2.com") }
            );
        }
    }
