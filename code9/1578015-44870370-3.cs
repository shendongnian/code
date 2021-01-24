    public static bool DoesPartialViewExist(this HtmlHelper html, string partialViewName) {
        var controllerContext = html.ViewContext.Controller.ControllerContext;
        var viewEngineResult = ViewEngines.Engines.FindPartialView(controllerContext, partialViewName);
        return (viewEngineResult.View != null);
    }
