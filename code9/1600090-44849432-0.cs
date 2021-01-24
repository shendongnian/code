    public class RouteOne : NancyModule
    {
        public RouteOne()
        {
            if (xxx.License != LicenseType.RouteOne) return;
            Get["/"] = _ => Response.AsJson(new {Message = "This is route one"});
        }
    }
    public class RouteTwo : NancyModule
    {
        public RouteTwo()
        {
            if (xxx.License != LicenseType.RouteTwo) return;
            Get["/"] = _ => Response.AsJson(new { Message = "This is route two" });
        }
    }
