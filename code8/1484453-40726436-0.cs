    public class ClaimsTransformer : IClaimsTransformer
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ((ClaimsIdentity)principal.Identity).AddClaim(new Claim("Admin", "true"));
            return Task.FromResult(principal);
        }
    }
