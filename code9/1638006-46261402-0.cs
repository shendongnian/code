    app.UseWhen(context => context.Request.Path.Value.StartsWith("/api"), builder =>
    {
        ...jwt code...
        builder.MapWhen((ctx) =>
        {
            var userName = ctx.User.Claims.SingleOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Name)?.Value ?? "";
            return String.IsNullOrWhiteSpace(userName) || !ctx.Request.Path.StartsWithSegments(new Microsoft.AspNetCore.Http.PathString($"/api/v1/{userName}"));
        }, cfg =>
        {
            cfg.Run((req) =>
            {
                req.Response.StatusCode = 403;
                return req.Response.WriteAsync("");
            });
        });
    });
    
