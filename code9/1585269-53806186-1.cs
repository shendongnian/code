    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Add parameters to token
            ClaimsIdentity oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            context.Validated(oAuthIdentity);
            return base.GrantResourceOwnerCredentials(context);
        }
    }
