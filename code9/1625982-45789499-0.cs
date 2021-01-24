    public class QueryStringAuthOptions : AuthenticationOptions
    {
        public QueryStringAuthOptions()
        {
            AuthenticationScheme = "QueryStringAuth";
        }
    
        public string QueryStringKeyParam { get; set; } = "key";
    
        public string ClaimsTypeName { get; set; } = "QueryStringKey";
    
        public AuthenticationProperties AuthenticationProperties { get; set; } = new AuthenticationProperties();
    }
    
    public class QueryStringAuthHandler : AuthenticationHandler<QueryStringAuthOptions>
    {
        /// <summary>
        /// Handle authenticate async
        /// </summary>
        /// <returns></returns>
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (Request.Query.TryGetValue(Options.QueryStringKeyParam, out StringValues value) && value.Count > 0)
            {
                var key = value[0];
    
                //..do your authentication...
    
                if (!string.IsNullOrWhiteSpace(key))
                {
                    //setup you claim
                    var claimsPrinciple = new ClaimsPrincipal();
                    claimsPrinciple.AddIdentity(new ClaimsIdentity(new[] { new Claim(Options.ClaimsTypeName, key) }, Options.AuthenticationScheme));
    
                    //create the result ticket
                    var ticket = new AuthenticationTicket(claimsPrinciple, Options.AuthenticationProperties, Options.AuthenticationScheme);
                    var result = AuthenticateResult.Success(ticket);
                    return Task.FromResult(result);
                }
            }
            return Task.FromResult(AuthenticateResult.Fail("Key not found or not valid"));
    
        }
    }
