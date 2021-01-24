    public override void OnAuthorization(HttpActionContext actionContext) {
        var actionDescriptor = actionContext.ActionDescriptor;
        var actionName = actionDescriptor.ActionName;
        var controllerName = actionDescriptor.ControllerDescriptor.ControllerName;
        //MethodName = "mycontroller/get"
        var methodName = string.Format("{0}/{1}", controllerName, actionName);
    }
