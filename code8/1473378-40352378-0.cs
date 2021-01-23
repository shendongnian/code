    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        loggerFactory.AddDebug();
        //Custom authentication middleware.
        app.Use(async (context, next) =>
        {
            //Validate security here and proceed to the next line if everything is ok.
            //Replace the parameter with the username from the request.
            context.User = new System.Security.Claims.ClaimsPrincipal(new GenericIdentity("MyUser"));
            //Will return true.
            Console.WriteLine("Is authenticated: ${context.User.Identity.IsAuthenticated}");
            await next();
        });
        app.UseMvc();
    }
