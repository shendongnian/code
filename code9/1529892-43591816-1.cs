    public sealed class UpdateFileResponseTypeFilter : IOperationFilter
        {
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                if (apiDescription.GetControllerAndActionAttributes<SwaggerResponseRemoveDefaultsAttribute>().Any())
                {
                    operation.responses.Clear();
                }
                var responseAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerFileResponseAttribute>()
                    .OrderBy(attr => attr.StatusCode);
    
                foreach (var attr in responseAttributes)
                {
                    var statusCode = attr.StatusCode.ToString();
    
                    Schema responseSchema = new Schema { format = "byte", type = "file" };
    
                    operation.produces.Clear();
                    operation.produces.Add("application/octet-stream");
    
                    operation.responses[statusCode] = new Response
                    {
                        description = attr.Description ?? InferDescriptionFrom(statusCode),
                        schema = responseSchema
                    };
                }
            }
    
            private string InferDescriptionFrom(string statusCode)
            {
                HttpStatusCode enumValue;
                if (Enum.TryParse(statusCode, true, out enumValue))
                {
                    return enumValue.ToString();
                }
                return null;
            }
        }
