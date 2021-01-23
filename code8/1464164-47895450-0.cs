       public void ConfigureServices(IServiceCollection services)
        {
            
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:5000").AllowAnyHeader()
                    .AllowAnyMethod());
            });
            services.AddMvc()
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug(LogLevel.Information);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // Shows UseCors with named policy.
            app.UseCors("AllowSpecificOrigin");
            app.UseStaticFiles();
            app.UseAuthentication();
            
            app.UseMvcWithDefaultRoute();
        }
    }
