    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<GeoSalesLogger>>();
        ...
    }
    
