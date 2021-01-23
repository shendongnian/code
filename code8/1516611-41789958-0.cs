            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                //service should has been configured in ConfigureServices step
                //Create method to check if data loaded. If not then load them.
                serviceScope.ServiceProvider.GetService<ApplicationDbContext>().CheckDataLoaded();
            }
            //more steps here..
