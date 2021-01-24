    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                    {
                        HotModuleReplacement = true
                    });
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }
    
                app.UseDefaultFiles();
                app.UseStaticFiles();
                app.Use(async (context, next) =>
                {
                    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("api"))
                    {
                        context.Request.Path = "/Index.cshtml";
                        context.Response.StatusCode = 200;
                        await next();
                    }
                });
            }
