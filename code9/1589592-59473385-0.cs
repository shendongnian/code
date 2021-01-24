        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {      
           app.UseCors(builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials()
                );
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
        }
