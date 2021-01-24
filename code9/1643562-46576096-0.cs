    class ClaimsPrincipalValueProvider : IValueProvider
    {
        public ClaimsPrincipal Principal { get; set; }
        public ClaimsPrincipalValueProvider(ClaimsPrincipal principal)
        {
            Principal = principal;
        }
        public bool ContainsPrefix(string prefix)
        {
            return Principal.HasClaim(claim => claim.Type.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase));
        }
        public ValueProviderResult GetValue(string key)
        {
            var claims = Principal.FindAll(claim => claim.Type.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            if (claims.Count() > 0)
            {
                var values = claims.Select(claim => claim.Value).ToArray();
                return new ValueProviderResult(values, null, CultureInfo.InvariantCulture);
            }
            return null;
        }
    }
    public class ClaimsPrincipalValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            if (actionContext.RequestContext.Principal != null && actionContext.RequestContext.Principal is ClaimsPrincipal principal)
                return new ClaimsPrincipalValueProvider(principal);
            return null;
        }
    }
