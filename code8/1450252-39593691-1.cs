    public ActionResult Index()
    {
        var controllerName = // logic to get Controller name (already have)
        var viewName = // logic to get View name (already have)
    
            
        //get the current assembly
        Type t = typeof(PageController);
        Assembly assemFromType = t.Assembly;
        
        //get the controller type from the assembly
        Type controllerType = assemFromType.GetType("Namespece." + controllerName);
        //get the action method info
        MethodInfo actionMethodInfo = controllerType.GetMethods(viewName);
        
        //create an instance of the controller
        object controllerInstance = Activator.CreateInstance(controllerType, null);
        //invoke the action on the controller instance
        return (ActionResult)actionMethodInfo.Invoke(controllerInstance, null);
    }
