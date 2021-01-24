        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOData();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Document>("Documents");
            app.UseMvc(builder =>
            {
                builder.MapODataRoute("odata", modelBuilder.GetEdmModel());
            });
        }
