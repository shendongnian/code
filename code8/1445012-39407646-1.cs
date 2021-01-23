    	public class ApplyOAuth2Security : IDocumentFilter, IOperationFilter
	{
		public void Apply(Operation operation, OperationFilterContext context)
		{
			var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
			var isAuthorized = filterPipeline.Select(f => f.Filter).Any(f => f is AuthorizeFilter);
			var authorizationRequired = context.ApiDescription.GetControllerAttributes().Any(a => a is AuthorizeAttribute);
			if (!authorizationRequired) authorizationRequired = context.ApiDescription.GetActionAttributes().Any(a => a is AuthorizeAttribute);
			if (isAuthorized && authorizationRequired)
			{
				operation.Parameters.Add(new NonBodyParameter()
				{
					Name = "Authorization",
					In = "header",
					Description = "JWT security token obtained from Identity Server.",
					Required = true,
					Type = "string"
				});
			}
		}
		public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
		{
			IList<IDictionary<string, IEnumerable<string>>> security = swaggerDoc.SecurityDefinitions.Select(securityDefinition => new Dictionary<string, IEnumerable<string>>
			{
				{securityDefinition.Key, new string[] {"yourapi"}}
			}).Cast<IDictionary<string, IEnumerable<string>>>().ToList();
			swaggerDoc.Security = security;
		}
	}
