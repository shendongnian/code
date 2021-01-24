     public class AuthorizeViewFilterProvider : System.Web.Http.Filters.IFilterProvider
        {
            private readonly Func<AuthorizeViewFilter> _authorizeViewFilterFactory;
    
            public AuthorizeViewFilterProvider(Func<AuthorizeViewFilter> authorizeViewFilterFactory)
            {
                this._authorizeViewFilterFactory = authorizeViewFilterFactory;
            }
    
            public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
            {
                if(!actionDescriptor.GetCustomAttributes<AuthorizeViewAttribute>().Any())
                    return Enumerable.Empty<FilterInfo>();
                return new[]
                {
                    new FilterInfo(this._authorizeViewFilterFactory(), FilterScope.Action)
                };
            }
        }
    
