    public class ClaimAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public ClaimAuthenticationFilter()
        {
        }
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            if (context.Principal != null && context.Principal.Identity.IsAuthenticated)
            {
                var windowsPrincipal = context.Principal as WindowsPrincipal;
                var handler = new HttpClientHandler()
                {
                    UseDefaultCredentials = true
                };
                HttpClient client = new HttpClient(handler);
                client.BaseAddress = new Uri("http://localhost:21989");// to be stored in config
                var response = await client.GetAsync("/Security");
                var contents = await response.Content.ReadAsStringAsync();
                var claimsmodel = JsonConvert.DeserializeObject<List<ClaimsModel>>(contents);
                if (windowsPrincipal != null)
                {
                    var name = windowsPrincipal.Identity.Name;
                    var identity = new ClaimsIdentity();
                    
                    foreach (var claim in claimsmodel)
                    {
                        identity.AddClaim(new Claim("process", claim.ClaimName));
                    }
                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    context.Principal = claimsPrincipal;
                }
            }
            await Task.FromResult(0);
        }
        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var challenge = new AuthenticationHeaderValue("Negotiate");
            context.Result = new ResultWithChallenge(challenge, context.Result);
            await Task.FromResult(0);
        }
    }
