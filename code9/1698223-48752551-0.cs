        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>() 
                        .CreateScope()) 
            { 
                serviceScope.ServiceProvider.GetService<DatabaseApplicationContext>() 
                    .Database.Migrate(); 
            } 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
