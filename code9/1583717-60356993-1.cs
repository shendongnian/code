    // ApiKeyOperationFilter.cs
    // ...
    internal class ApiKeyOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Piggy back off of SecurityRequirementsOperationFilter from Swagger.AspNetCore.Filters which has oauth2 as the default security scheme.
            var filter = new SecurityRequirementsOperationFilter(securitySchemaName: ApiKeyAuthenticationOptions.DefaultScheme);
            filter.Apply(operation, context);
        }
    }
