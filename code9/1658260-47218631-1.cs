    public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }
        public void ConfigureOAuth(IAppBuilder app)
        {
            // Configure the application for OAuth based flow
            PublicClientId = "theDragonIsAlive";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new YourOwnApplicationOAuthProvider(PublicClientId),
                //AuthorizeEndpointPath = new PathString("/Access/Account"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(7)
                //AllowInsecureHttp = true
            };
            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }
            _publicClientId = publicClientId;
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            // This where you are validating the username and password credentials.
            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("Dragon Fire:", "The user name or password is incorrect. You shall be burnt.");
                return;
            }
            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            AuthenticationProperties properties = CreateProperties(user.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(oAuthIdentity);
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
        // This method is where you will create the client access token.
        // First you get the client, you can place values from the client record into the tokens claim collection.
        // You then create a new ClaimsIdentity.
        // You add some claims, in the example client name is added.
        // Create an AuthenticationTicket using your claims identity.
        // Validate the ticket (you do need to do this or the client will be considered unauthenticated)
        //public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        //{
        //    var client = clientService.GetClient(context.ClientId);
        //    var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
        //    oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, client.ClientName));
        //    var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
        //    context.Validated(ticket);
        //    return base.GrantClientCredentials(context);
        //}
        // This method has to be implmented when you are maintaining a list of clients which you will allow.
        // This method is for validating the input, you can used this method to verify the client id and secret are valid.
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //string clientId;
            //string clientSecret;
            //context.TryGetFormCredentials(out clientId, out clientSecret);
            //if (clientId == "1234" && clientSecret == "12345")
            //{
            //    context.Validated(clientId);
            //}
            //return base.ValidateClientAuthentication(context);
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");
                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }
            return Task.FromResult<object>(null);
        }
        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
