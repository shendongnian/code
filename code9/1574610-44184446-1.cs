    services.AddMvc();
            var defaultApiVer = new ApiVersion(1, 0);
           
            services.AddApiVersioning(option =>
            {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = defaultApiVer;
            });
            services.AddMvcCore().AddVersionedApiExplorer(e=>e.DefaultApiVersion = defaultApiVer);
            
            services.AddSwaggerGen(
                options =>
                {
                    var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                    options.DocumentFilter<VersionedOperationsFilter>();
                    //// add a swagger document for each discovered API version
                    //// note: you might choose to skip or document deprecated API versions differently
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                            options.SwaggerDoc(description.GroupName.ToString(),
                                CreateInfoForApiVersion(description));
                    }
                    //// integrate xml comments
                    options.IncludeXmlComments(Path.ChangeExtension(Assembly.GetEntryAssembly().Location, "xml"));
                });
