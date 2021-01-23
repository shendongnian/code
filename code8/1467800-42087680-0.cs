    public class FacebookAuthProvider : FacebookAuthenticationProvider
    {
        public override Task Authenticated(FacebookAuthenticatedContext context)
        {
            var accessTokenClaim = new Claim("ExternalAccessToken", context.AccessToken, "urn:facebook:access_token");
            context.Identity.AddClaim(accessTokenClaim);
            var extraClaims = GetAdditionalFacebookClaims(accessTokenClaim);
            context.Identity.AddClaim(new Claim(ClaimTypes.Email, extraClaims.First(k => k.Key == "email").Value.ToString()));
            context.Identity.AddClaim(new Claim("Provider", context.Identity.AuthenticationType));
            context.Identity.AddClaim(new Claim(ClaimTypes.Name, context.Identity.FindFirstValue(ClaimTypes.Name)));
    
            var userDetail = context.User;
            var link = userDetail.Value<string>("link") ?? string.Empty;
            context.Identity.AddClaim(new Claim("link", link));
            context.Identity.AddClaim(new Claim("FacebookId", userDetail.Value<string>("id")));
            return System.Threading.Tasks.Task.FromResult(0);
        }
    
        private static JsonObject GetAdditionalFacebookClaims(Claim accessToken)
        {
            var fb = new FacebookClient(accessToken.Value);
            return fb.Get("me", new { fields = new[] { "email", "first_name", "last_name" } }) as JsonObject;
        }
    }
