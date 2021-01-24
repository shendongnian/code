    public class RouteDataRequestCultureProvider : RequestCultureProvider
    {
    
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }
            string culture = null;
            string uiCulture = null;
             uiCulture =  culture = httpContext.Request.Path.Value.Split('/')[1]?.ToString();
            if (culture == null)
            {
                return TaskCache<ProviderCultureResult>.DefaultCompletedTask;
            }
            var providerResultCulture = new ProviderCultureResult(culture, uiCulture);
            return Task.FromResult(providerResultCulture);
        }
    } 
