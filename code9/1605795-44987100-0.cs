    public override void OnException(ExceptionContext context)
    {
        context.HttpContext.Response.Headers.Add("CorrelationId", new string[] { "12345" });
        context.Result = new ObjectResult(null) { StatusCode = 500 };
        context.ExceptionHandled = true;
        base.OnException(context);
    }
