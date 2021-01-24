        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // ...
            //some code 
            app.UseAuthentication();
            app.UseAdAuthorizationMiddleware();
            // some routing 
            // ...
        }
