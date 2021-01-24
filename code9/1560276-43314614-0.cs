    public static bool ViewExists(this Controller controller, string viewName)
    {
        // check for viewName null or empty here?
        if (!Regex.IsMatch(viewName, "^[A-Za-z0-9_]+$"))
            throw new HttpException(404, "Not found");
        var result = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, null);
        return result.View != null;
    }
