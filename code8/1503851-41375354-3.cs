    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        if (actionContext.Request.Properties.ContainsKey("ShouldLog"))
        {
           // Parse and check the value of ShouldLog before returning when false.
           return;
        }
        // Some business logic
    }
