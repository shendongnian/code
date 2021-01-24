    public class CustomHomePageRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData result = null;
            // Only handle the home page route
            if (httpContext.Request.Path == "/")
            {
                var cid = httpContext.Request.QueryString["cid"];
                var pid = httpContext.Request.QueryString["pid"];
                result = new RouteData(this, new MvcRouteHandler());
                if (string.IsNullOrEmpty(cid) && string.IsNullOrEmpty(pid))
                {
                    // Go to the HomeController.Index action of the non-area
                    result.Values["controller"] = "Home";
                    result.Values["action"] = "Index";
                    // NOTE: Since the controller names are ambiguous between the non-area
                    // and area route, this extra namespace info is required to disambiguate them.
                    // This is not necessary if the controller names differ.
                    result.DataTokens["Namespaces"] = new string[] { "WebApplication23.Controllers" };
                }
                else
                {
                    // Go to the HomeController.Index action of the SID area
                    result.Values["controller"] = "Home";
                    result.Values["action"] = "Index";
                    // This tells MVC to change areas to SID
                    result.DataTokens["area"] = "SID";
                    // Set additional data for sipModel.
                    // This can be read from the HomeController.Index action by 
                    // adding a parameter "int sipModel".
                    result.Values["sipModel"] = 1;
                    // NOTE: Since the controller names are ambiguous between the non-area
                    // and area route, this extra namespace info is required to disambiguate them.
                    // This is not necessary if the controller names differ.
                    result.DataTokens["Namespaces"] = new string[] { "WebApplication23.Areas.SID.Controllers" };
                }
            }
            // If this isn't the home page route, this should return null
            // which instructs routing to try the next route in the route table.
            return result;
        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            var controller = Convert.ToString(values["controller"]);
            var action = Convert.ToString(values["action"]);
            if (controller.Equals("Home", StringComparison.OrdinalIgnoreCase) &&
                action.Equals("Index", StringComparison.OrdinalIgnoreCase))
            {
                // Route to the Home page URL
                return new VirtualPathData(this, "");
            }
            return null;
        }
    }
