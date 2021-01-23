    public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // Configure versions 
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            // Configure swagger
            services.AddSwaggerGen(options =>
            {
                // Specify two versions 
                options.SwaggerDoc("v1", 
                    new Info()
                    {
                        Version = "v1",
                        Title = "v1 API",
                        Description = "v1 API Description",
                        TermsOfService = "Terms of usage v1"
                    });
                options.SwaggerDoc("v2",
                    new Info()
                    {
                        Version = "v2",
                        Title = "v2 API",
                        Description = "v2 API Description",
                        TermsOfService = "Terms of usage v2"
                    });
                // This call remove version from parameter, without it we will have version as parameter 
                // for all endpoints in swagger UI
                options.OperationFilter<RemoveVersionFromParameter>();
                // This make replacement of v{version:apiVersion} to real version of corresponding swagger doc.
                options.DocumentFilter<ReplaceVersionWithExactValueInPath>();
                // This on used to exclude endpoint mapped to not specified in swagger version.
                // In this particular example we exclude 'GET /api/v2/Values/otherget/three' endpoint,
                // because it was mapped to v3 with attribute: MapToApiVersion("3")
                options.DocInclusionPredicate((version, desc) =>
                {
                    var versions = desc.ControllerAttributes()
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);
                    var maps = desc.ActionAttributes()
                        .OfType<MapToApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions)
                        .ToArray();
                    return versions.Any(v => $"v{v.ToString()}" == version) && (maps.Length == 0 || maps.Any(v => $"v{v.ToString()}" == version));
                });
            });
        }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v2/swagger.json", $"v2");
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
            });
            app.UseMvc();
        }
