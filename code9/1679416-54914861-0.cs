     public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
     {
            var authorizeAttributes = apiDescription.ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>().Any() 
                                             ? apiDescription.ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>()
                                             : apiDescription.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AuthorizeAttribute>();
                                      
            if (!authorizeAttributes.Any())
                return;
            if (operation.security == null)
                operation.security = new List<IDictionary<string, IEnumerable<string>>>();
            var oAuthRequirements = new Dictionary<string, IEnumerable<string>>
            {
                { "oauth2", Enumerable.Empty<string>() }
            };
            operation.security.Add(oAuthRequirements);
     }
