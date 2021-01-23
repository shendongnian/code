    public class AssignOperationFilters : IOperationFilter
        {              
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {     
                string clientId = "clientID";
                if (apiDescription != null)
                {
                    var actFilters = apiDescription.ActionDescriptor.GetFilterPipeline();
    
                    var allowsAnonymous = actFilters.Select(f => f.Instance).OfType<OverrideAuthorizationAttribute>().Any();
                    if (allowsAnonymous)
                    {
                        return; // must be an anonymous method
                    }
                }
    
                if (operation != null)
                {
                    if (operation.security == null)
                    {
                        operation.security = new List<IDictionary<string, IEnumerable<string>>>();
                    }
    
                    var authRequirements = new Dictionary<string, IEnumerable<string>>
                    {
                        { "oauth2", new List<string> { clientId } }
                    };
    
                    operation.security.Add(authRequirements);
                }
            }
        }
