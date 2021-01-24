    class CustomOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var responses = operation.responses;
			if (!responses.ContainsKey("200"))
			{
				if (apiDescription.ActionDescriptor.ReturnType != null)
				{
					responses.Add("200", new Response()
					{
						description = "OK",
						schema = (schemaRegistry.GetOrRegister(apiDescription.ActionDescriptor.ReturnType))
					});
				}
			}
        }
    }
