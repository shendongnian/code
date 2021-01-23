    internal class DecisionMakingFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var actionName= actionContext.ActionDescriptor.ActionName;
            if(actionName == "Some Foo")
            {
                actionContext.RequestContext.Configuration.Formatters.Add(new CustomMediaFormatter());
            }
            base.OnActionExecuting(actionContext);
            actionContext.RequestContext.Configuration.Formatters.Remove(new CustomMediaFormatter());
        }
    }
