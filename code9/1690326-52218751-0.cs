    app.Use(async (context, next) =>
            {
                // Write some code that determines the scheme based on the incoming request
                string scheme = GetSchemeForRequest(context);
                var result = await context.AuthenticateAsync(scheme);
                if (result.Succeeded)
                {
                    context.User = result.Principal;
                }
                await next();
            });
