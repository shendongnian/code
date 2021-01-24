    app.Use(async (ctx, next) =>
    {
        if (ctx.Authentication.User.Identity.IsAuthenticated == false)
        {
            ctx.Response.StatusCode = 401;
            return;
        }
        await next();
    });
