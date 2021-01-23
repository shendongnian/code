    public override void OnActionExecuting(ActionExecutingContext context)
    {
            if(context.HttpContext.Request.Headers.ContainsKey("key"))
            {
                context.HttpContext.Response.StatusCode = 401;              
                NotExecuteAction = true;
            }
           
            if (NotExecuteAction)
            {
                context.Result = NoContent;
            }
            base.OnActionExecuting(context);           
    }
