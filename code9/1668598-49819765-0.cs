    public class CustomGoogleHandler : OAuthHandler<CustomGoogleOptions>
        {
            public CustomGoogleHandler(IOptionsMonitor<CustomGoogleOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
                : base(options, logger, encoder, clock)
            {
            }
    
            protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
            {
                // code omited for simplicity
            }
    
            protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    {"response_type", "code"},
                    {"client_id", Options.ClientId},
                    {"redirect_uri", redirectUri}
                };
                AddQueryString(dictionary, properties, "scope", FormatScope());
                AddQueryString(dictionary, properties, "access_type", Options.AccessType);
                AddQueryString(dictionary, properties, "hd", Options.HostedDomain);
                AddQueryString(dictionary, properties, "approval_prompt");
                AddQueryString(dictionary, properties, "prompt");
                AddQueryString(dictionary, properties, "login_hint");
                AddQueryString(dictionary, properties, "include_granted_scopes");
                string str = Options.StateDataFormat.Protect(properties);
                dictionary.Add("state", str);
                return QueryHelpers.AddQueryString(Options.AuthorizationEndpoint, dictionary);
            }
    
            private static void AddQueryString(IDictionary<string, string> queryStrings, AuthenticationProperties properties, string name, string defaultValue = null)
            {
                // code omited for simplicity
            }
        }
