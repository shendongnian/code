    private static string RenderViewIntoString(ViewResult viewResult, ActionExecutedContext filterContext)
    {
    	string viewName = !string.IsNullOrEmpty(viewResult.ViewName) ? viewResult.ViewName : filterContext.ActionDescriptor.ActionName;
    
    	IView view = viewResult.ViewEngineCollection.FindView(filterContext.Controller.ControllerContext, viewName, viewResult.MasterName).View;
    
    	if (view == null)
    	{
    		throw new InvalidOperationException($"The view '{viewName}' or its master was not found");
    	}
    
    	using (var stringWriter = new StringWriter())
    	{
    		var viewContext = new ViewContext(filterContext.Controller.ControllerContext, view, filterContext.Controller.ViewData, filterContext.Controller.TempData, stringWriter);
    		view.Render(viewContext, stringWriter);
    		return stringWriter.ToString();
    	}
    }
