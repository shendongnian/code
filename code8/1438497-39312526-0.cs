    public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
    {
        if ((actionDescriptor.ControllerDescriptor.ControllerType == typeof(GemStoneProject.GemStoneController)) &&
            (actionDescriptor.ActionName.Equals("GemStoneAction")) && controllerContext.HttpContext.Request.HttpMethod == "POST")
        {
            return new List<Filter>() { new Filter(this, FilterScope.Action, 0) };
        }
    
        return new List<Filter>() { };
    }
    
    
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        /*your code, that replaces previous View to new View. 
    You have available and valid .ControllerContext inside "filterContext" argument*/
        }
