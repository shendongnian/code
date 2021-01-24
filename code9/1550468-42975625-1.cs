    public class CustomViewEngine : RazorViewEngine
    {
          public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
          {
               var viewPath = controllerContext.HttpContext.Request.Browser.IsMobileDevice ? "MobilePath" : "defaultPath";
               return base.FindView(controllerContext, viewPath, "MasterName", useCache);
          }
    }
