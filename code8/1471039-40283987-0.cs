    public void ConfigureApplication(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        ...
        
        app.UseIISPlatformHandler();
        app.UseStaticFiles();
        
    	app.UseCookieAuthentication(options =>
    	{
    		options.AutomaticAuthenticate = true;
    	});            
        
    	app.UseOpenIdConnectAuthentication(options =>
    	{
    		options.AutomaticChallenge = true;
    		options.ClientId = Configuration.Get<string>("Authentication:AzureAd:ClientId");
    		options.Authority = Configuration.Get<string>("Authentication:AzureAd:AADInstance") + "Common";
    		options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    
    		options.TokenValidationParameters = new TokenValidationParameters
    		{
    		    ValidateIssuer = false,
    		    RoleClaimType = "roles"
    		};
    		options.Events = new OpenIdConnectEvents
    		{
    		    OnAuthenticationValidated = (context) => Task.FromResult(0),
    		    OnAuthenticationFailed = (context) =>
    		    {
    			   context.Response.Redirect("/Home/Error");
    			   context.HandleResponse(); // Suppress the exception
    			   return Task.FromResult(0);
    		    },
    		    OnRemoteError = (context) => Task.FromResult(0)
    		};
    	});
        
    	app.UseMvc(routes =>
    	{
    	   routes.MapRoute(name: "default", template: "{controller=Dashboard}/{action=Index}/{id?}");                
    	});
        
        DatabaseInitializer.InitializaDatabaseAsync(app.ApplicationServices).Wait();
    }
