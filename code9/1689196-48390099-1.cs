    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddOpenIdConnect(o =>
        {
            o.Events.OnAuthorizationCodeReceived = async ctx =>
            {
                var db = ctx.HttpContext.RequestServices.GetService<DbContext>();
                await ...
            };
        });
