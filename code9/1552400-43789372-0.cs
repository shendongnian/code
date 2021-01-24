    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            //Accept All HTTP Request Methods from all origins
            app.UseCors(builder =>
                builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            app.UseMvc();
        }
