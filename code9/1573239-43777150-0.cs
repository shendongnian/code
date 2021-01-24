    public class MyAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
        if(Authenticate(context.UserName, context.Password))
            ...
        }
    }
