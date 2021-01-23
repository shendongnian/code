    services.ConfigureSwaggerGen(options =>
    {
        options.OperationFilter<AddRequiredHeaderParameter>();
        options.SingleApiVersion(new Info
        {
            Version = "v1",
            Title = "Test",
            Description = "Test Service",
            TermsOfService = "None"
        });
        options.DescribeAllEnumsAsStrings();
    });
