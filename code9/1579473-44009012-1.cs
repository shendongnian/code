    Config.EnableSwagger((c) =>
    {
        c.SingleApiVersion("v1", "Flynn Forms");
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    }).EnableSwaggerUi();
