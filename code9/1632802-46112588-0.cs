            var apiExplorer = config.AddVersionedApiExplorer(options => {
                options.GroupNameFormat = "'v'VVV";
            });
            var versionSupportResolver = new Func<ApiDescription, string, bool>((apiDescription, version) => apiDescription.GetGroupName() == version);
            var versionInfoBuilder = new Action<VersionInfoBuilder>(info => {
                foreach (var group in apiExplorer.ApiDescriptions)
                {
                    info.Version(group.Name, $"MyAPI v{group.ApiVersion}");
                }
            });
            config
                .EnableSwagger("{apiVersion}/swagger", swagger => {
                    swagger.OperationFilter<SwaggerDefaultValues>();
                    swagger.MultipleApiVersions(versionSupportResolver, versionInfoBuilder);
                    swagger.IncludeXmlComments(WebApiConfig.XmlCommentsFilePath);
                })
                .EnableSwaggerUi(swaggerUi => {
                    swaggerUi.EnableDiscoveryUrlSelector();
                    swaggerUi.DocExpansion(DocExpansion.List);
                });
