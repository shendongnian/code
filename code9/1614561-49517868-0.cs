    public void ConfigureServices( IServiceCollection services )
    {
        // note: this option is only necessary when versioning by url segment.
        // the SubstitutionFormat property can be used to control the format of the API version
        services.AddMvcCore().AddVersionedApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            } );
        services.AddMvc();
        services.AddApiVersioning();
        services.AddSwaggerGen(
            options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach ( var description in provider.ApiVersionDescriptions )
                {
                    options.SwaggerDoc( description.GroupName, CreateInfoForApiVersion( description ) );
                }
                options.IncludeXmlComments( XmlCommentsFilePath );
            } );
    }
    public void Configure( IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider )
    {
        app.UseMvc();
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                foreach ( var description in provider.ApiVersionDescriptions )
                {
                    options.SwaggerEndpoint( $"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant() );
                }
            } );
    }
    static string XmlCommentsFilePath
    {
        get
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var fileName = typeof( Startup ).GetTypeInfo().Assembly.GetName().Name + ".xml";
            return Path.Combine( basePath, fileName );
        }
    }
    static Info CreateInfoForApiVersion( ApiVersionDescription description )
    {
        var info = new Info()
        {
            Title = $"Sample API {description.ApiVersion}",
            Version = description.ApiVersion.ToString(),
            Description = "A sample application with Swagger, Swashbuckle, and API versioning.",
            Contact = new Contact() { Name = "Bill Mei", Email = "bill.mei@somewhere.com" },
            TermsOfService = "Shareware",
            License = new License() { Name = "MIT", Url = "https://opensource.org/licenses/MIT" }
        };
        if ( description.IsDeprecated )
        {
            info.Description += " This API version has been deprecated.";
        }
        return info;
    }
