    app.Use(async (context, next) =>
    {
        try
        {
            await next();
        }
        catch (Exception ex)
        {
            // let’s log the exception
            var logger = context.RequestServices.GetService<ILogger<Startup>>();
            logger.LogWarning(ex, "Encountered an exception");
            // write a response
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Sorry, something went wrong!");
        }
    });
