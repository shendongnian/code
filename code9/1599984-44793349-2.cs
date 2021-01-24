    public void ConfigureServices(IServiceCollection services)
        {   
            services.AddTransient<IDynamicTypeFactory, DynamicTypeFactory>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IDynamicTypeFactory dynamicTypeFactory)
        {
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Run(async (context) =>
            {
                var t = (IClass)dynamicTypeFactory.New("WebApplication1.Class1");
                await context.Response.WriteAsync(t.Test());
            });
        }
