        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            UserManager<ApplicationUser> _userManager;
            ApplicationDbContext db = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            try
            {
                ApplicationUser user = await _userManager.FindAsync(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));
                context.Validated(identity);
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
            }
            db.Dispose();
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = "";
            string clientSecret = "";
            context.TryGetFormCredentials(out clientId, out clientSecret);
            List<string> validClients = new List<string>(){ "web","Alliance_UWP","Alliance_Xamarin","Alliance_Web" };
            if (validClients.Contains(clientId))
                context.Validated();
        }
