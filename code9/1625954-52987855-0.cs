    internal class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            context.ApiDescription.TryGetMethodInfo(out var methodInfo);
    
            if (methodInfo == null)
                 return;
    
            var hasAuthorizeAttribute = false;
    
            if (methodInfo.MemberType == MemberTypes.Method)
            {
                // NOTE: Check the controller itself has Authorize attribute
                hasAuthorizeAttribute = methodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();
    
                // NOTE: Controller has Authorize attribute, so check the endpoint itself.
                //       Take into account the allow anonymous attribute
                if (hasAuthorizeAttribute)
                    hasAuthorizeAttribute = !methodInfo.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any();
                else
                    hasAuthorizeAttribute = methodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();
            }
    
            if (!hasAuthorizeAttribute)
                return;
    
            operation.Responses.Add(StatusCodes.Status401Unauthorized.ToString(), new Response { Description = "Unauthorized" });
            operation.Responses.Add(StatusCodes.Status403Forbidden.ToString(), new Response { Description = "Forbidden" });
    
            // NOTE: This adds the "Padlock" icon to the endpoint in swagger, 
            //       we can also pass through the names of the policies in the string[]
            //       which will indicate which permission you require.
            operation.Security = new List<IDictionary<string, IEnumerable<string>>>();
            operation.Security.Add(new Dictionary<string, IEnumerable<string>>
            {
                { "Bearer", new string[] { } }
            });
        }
    }
