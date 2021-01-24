    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute
            (
                name: "AdminDefault",
                url: "admin/{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", area = "admin", id = ""},
                namespaces: new[] {"Foo.Admin.Controllers"}
            );
        }
    }
