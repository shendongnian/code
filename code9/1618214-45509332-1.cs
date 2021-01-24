       // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                loggerFactory.AddConsole();
    
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
    
                app.UseReact(config =>
                {
                });
    
                app.UseStaticFiles();
                app.UseMvcWithDefaultRoute();
            }
