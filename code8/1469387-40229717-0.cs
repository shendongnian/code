    public class MyViewEngine : RazorViewEngine 
    {
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var roleName = controllerContext.RouteData.GetRequiredString("role");
            var controllerName = controllerContext.RouteData.GetRequiredString("controller");
            var path = string.Format("~/Roles/{0}/Features/{1}/{1}.cshtml", roleName, controllerName);
            var layoutPath = string.Format("/Roles/Shared/_{0}Layout.cshtml", controllerName);
            return new ViewEngineResult(new RazorView(controllerContext, path, layoutPath, false, null), this);
        }
        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            var roleName = controllerContext.RouteData.GetRequiredString("role");
            var controllerName = controllerContext.RouteData.GetRequiredString("controller");
            var path = string.Format("~/Roles/{0}/Features/{1}/{1}.cshtml", roleName, controllerName);
            return new ViewEngineResult(new RazorView(controllerContext, path, null, false, null), this);
        }
    }
