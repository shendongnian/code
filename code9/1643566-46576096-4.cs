    public class ClaimsPrincipalValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            if (actionContext.RequestContext.Principal != null && actionContext.RequestContext.Principal is ClaimsPrincipal principal)
            {
                var pairs = principal.Claims.Select(claim => new KeyValuePair<string, string>(claim.Type, claim.Value));
                return new NameValuePairsValueProvider(pairs, CultureInfo.CurrentCulture);
            }
            return null;
        }
    }
