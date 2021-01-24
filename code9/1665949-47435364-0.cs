    public override void OnAuthorization(AuthorizationContext filterContext) {
        var actionDescriptor = filterContext.ActionDescriptor;
        var actionName = actionDescriptor.ActionName;
        var controllerName = ControllerDescriptor.ControllerName;
        //MethodName = "mycontroller/get"
        var methodName = string.Format("{0}/{1}", controllerName, actionName);
    }
