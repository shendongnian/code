    Plugins.Add(new OpenApiFeature
    {
        Tags =
        {
            new OpenApiTag
            {
                Name = "clubs",
                Description = "Customer club lookups",
            },
            new OpenApiTag
            {
                Name = "customers",
                Description = "Customer demographics, receipts and transactions",
            },
            new OpenApiTag
            {
                Name = "dates",
                Description = "Fiscal date breakdowns",
            },
        }
    });
