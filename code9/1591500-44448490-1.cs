    public class TenantViewEngine : RazorViewEngine
    {
        private string GetPrefix(ControllerContext controllerContext)
        {
            var result = string.Empty;
            var tenant = controllerContext.RouteData.Values[TenantActionFilterAttribute.Tenant] as string;
            if (!string.IsNullOrEmpty(tenant))
            {
                result = "Tenants/" + tenant + "/";
            }
            return result;
        }
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var prefix = GetPrefix(controllerContext);
            if (partialPath.StartsWith("~/"))
            {
                partialPath = partialPath.Insert(2, prefix);
            }
            else if (partialPath.StartsWith("~") || partialPath.StartsWith("/"))
            {
                partialPath = partialPath.Insert(1, prefix);
            }
            else if (string.IsNullOrEmpty(partialPath))
            {
                partialPath = prefix + partialPath;
            }
            return base.CreatePartialView(controllerContext, partialPath);
        }
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var prefix = GetPrefix(controllerContext);
            if (viewPath.StartsWith("~/"))
            {
                viewPath = viewPath.Insert(2, prefix);
            }
            else if (viewPath.StartsWith("~") || viewPath.StartsWith("/"))
            {
                viewPath = viewPath.Insert(1, prefix);
            }
            else if (!string.IsNullOrEmpty(viewPath))
            {
                viewPath = prefix + viewPath;
            }
            if (masterPath.StartsWith("~/"))
            {
                masterPath = masterPath.Insert(2, prefix);
            }
            else if (masterPath.StartsWith("~") || masterPath.StartsWith("/"))
            {
                masterPath = masterPath.Insert(1, prefix);
            }
            else if (!string.IsNullOrEmpty(masterPath))
            {
                masterPath = prefix + masterPath;
            }
            return base.CreateView(controllerContext, viewPath, masterPath);
        }
    }
