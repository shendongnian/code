     public static void ApiKeyMiddlewear(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments(new PathString("/api")))
                {
                    // Let's check if this is an API Call
                    if (context.Request.Headers["ApiKey"].Any())
                    {
                        // validate the supplied API key
                        // Validate it
                        var headerKey = context.Request.Headers["ApiKey"].FirstOrDefault();
                        await ValidateApiKey(serviceProvider, context, next, headerKey);
                    }
                    else if (context.Request.Query.ContainsKey("apikey"))
                    {
                        if (context.Request.Query.TryGetValue("apikey", out var queryKey))
                        {
                            await ValidateApiKey(serviceProvider, context, next, queryKey);
                        }
                    }
                    else
                    {
                        await next();
                    }
                }
                else
                {
                    await next();
                }
            });
        }
        private static async Task ValidateApiKey(IServiceProvider serviceProvider, HttpContext context, Func<Task> next, string key)
        {
            // validate it here
            var valid = false;
            if (!valid)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Invalid API Key");
            }
            else
            {
                var identity = new GenericIdentity("API");
                var principal = new GenericPrincipal(identity, new[] { "Admin", "ApiUser" });
                context.User = principal;
                await next();
            }
        }
