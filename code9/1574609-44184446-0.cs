    public class VersionedOperationsFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var apiDescriptionsGroup in context.ApiDescriptionsGroups.Items)
            {
                var version = apiDescriptionsGroup.GroupName;
                foreach (ApiDescription apiDescription in apiDescriptionsGroup.Items)
                {
                    apiDescription.RelativePath = apiDescription.RelativePath.Replace("{version}", version);
                }
            }
        }
    }
