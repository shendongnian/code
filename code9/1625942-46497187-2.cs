         public void Configure(IApplicationBuilder app, IHostingEnvironment env)
          {
        
                    if (env.IsDevelopment())
                    {
                        app.UseBrowserLink();
                        app.UseDeveloperExceptionPage();
                    }
                    else
                    {
                        app.UseExceptionHandler("/Home/Error");
                    }
        
                    app.UseStaticFiles();
                
                 app.UseMvc(routes =>
                    {
                        routes.MapRoute(
                       name: "default",
                       template: "{controller=Home}/{action=Index}/{id?}");                 
                    });        
    }
