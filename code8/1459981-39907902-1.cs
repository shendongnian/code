    services.AddSwaggerGen(options =>
    {
        options.OperationFilter<SwashbuckleOperationFilter>();
        options.SingleApiVersion(new Info
        {
            Version = "v1",
            Title = settings.ApplicationName,
            Description = settings.ApplicationName,
            TermsOfService = "None"
        });
        options.CustomSchemaIds(x =>
        {
            // add in the namespace location of the type (minus the project root part for shorter names) to avoid schema conflicts in swagger.
            var schemaName = string.Join("", x.FullName.Split('.').Skip(2));
            if (string.IsNullOrWhiteSpace(schemaName))
                schemaName = x.Name;
            return schemaName;
        });
        options.DescribeAllEnumsAsStrings();
        options.MapType<decimal>(() => new Schema { Type = "number", Format = "decimal" });
    });
