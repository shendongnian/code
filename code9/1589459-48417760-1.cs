    public static class SwaggerConfiguration
    {       
        public static void Configure(HttpConfiguration config)
        {
            var apiExplorer = config.AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'V");
            config.EnableSwagger(
                    swagger =>
                    {
                        swagger.MultipleApiVersions(
                            (apiDesc, targetApiVersion) => apiDesc.GetGroupName() == targetApiVersion,
                            versionBuilder =>
                            {
                                foreach (var group in apiExplorer.ApiDescriptions)
                                {
                                    var description = "";
                                    if (group.IsDeprecated) description += "This API deprecated";
                                    versionBuilder.Version(group.Name, $"Service API {group.ApiVersion}")
                                        .Description(description);
                                }
                            });
                        swagger.DocumentFilter<VersionFilter>();
                        swagger.OperationFilter<VersionOperationFilter>();
                    })
                .EnableSwaggerUi(cfg => cfg.EnableDiscoveryUrlSelector());
        }
