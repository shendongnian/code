    using Microsoft.Extensions.Caching.Memory;
    public class ClaimsTransformer : IClaimsTransformation
    {
        private readonly IMemoryCache _cache;
        public ClaimsTransformer(IMemoryCache cache)
        {
            _cache = cache;
        }
        
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var cacheKey = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_cache.TryGetValue(cacheKey, out List<Claim> claims)
		    {
                ((ClaimsIdentity)principal.Identity).AddClaims(claims);
			}
            else
            {
                claims = new List<Claim>();          
                
                // call to database to get more claims based on user id ClaimsIdentity.Name
                _cache.Set(cacheKey, claims);
            }
            return principal;
        }
    }
