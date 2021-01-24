    static IDictionary<string, bool> partialViewCache = new Dictionary<string, bool>();
    public static bool DoesPartialViewExist(this HtmlHelper html, string partialViewName) {
        bool value = false;
        if (partialViewCache.TryGetValue(partialViewName, out value)) {
            var controllerContext = html.ViewContext.Controller.ControllerContext;
            ViewEngineResult result = ViewEngines.Engines.FindPartialView(controllerContext, partialViewName);
            value = result.View != null;
            partialViewCache[partialViewName] = value;
        }
        return value;
    }
