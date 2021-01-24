    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddOpenIdConnect(o =>
        {
            o.Events.OnAuthorizationCodeReceived = ctx =>
            {
                var db = ctx.HttpContext.RequestServices.GetService<DbContext>();
                await ...
                return Task.CompletedTask;
            };
        });
