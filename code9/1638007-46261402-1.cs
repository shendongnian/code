    app.UseWhen(context => context.Request.Path.Value.StartsWith("/api"), builder =>
    {
        ...jwt code...
        builder.MapWhen((ctx) =>
        {
            var userName = ctx.User.Claims.SingleOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Name)?.Value ?? "";
            var testPath = new Microsoft.AspNetCore.Http.PathString($"/api/v2/computers/{userName}/");
            var pathMatch = ctx.Request.Path.StartsWithSegments(testPath);
            return String.IsNullOrWhiteSpace(userName) || !pathMatch;
        }, cfg =>
        {
            cfg.Run((req) =>
            {
                req.Response.StatusCode = 403;
                return req.Response.WriteAsync("");
            });
        });
    });
    
