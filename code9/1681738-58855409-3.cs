    public class AuthCallbackController : Controller
        {
            private readonly UserManager<ApplicationUser> userManager;
            private readonly IGoogleAnalyticsDataStore datastore;
    
            public AuthCallbackController(UserManager<ApplicationUser> userManager, IGoogleAnalyticsDataStore datastore)
            {
                this.userManager = userManager;
                this.datastore = datastore;
            }
    
            protected virtual ActionResult OnTokenError(TokenErrorResponse errorResponse)
            {
                throw new TokenResponseException(errorResponse);
            }
            public async virtual Task<ActionResult> Index(AuthorizationCodeResponseUrl authorizationCode,
                CancellationToken taskCancellationToken)
            {
                using (var stream = new FileStream("client_secret.json",
                     FileMode.Open, FileAccess.Read))
                {
                    IAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(
            new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = GoogleClientSecrets.Load(stream).Secrets,
                DataStore = datastore,
                Scopes = new[] { AnalyticsService.Scope.AnalyticsReadonly, AnalyticsReportingService.Scope.AnalyticsReadonly }
            });
    
                    if (string.IsNullOrEmpty(authorizationCode.Code))
                    {
                        var errorResponse = new TokenErrorResponse(authorizationCode);
    
                        return OnTokenError(errorResponse);
                    }
                    string userId = userManager.GetUserAsync(User).Result.Id;
                    var returnUrl = UriHelper.GetDisplayUrl(Request);
    
                    var token = await flow.ExchangeCodeForTokenAsync(userId, authorizationCode.Code, returnUrl.Substring(0, returnUrl.IndexOf("?")),
                        taskCancellationToken).ConfigureAwait(false);
    
                    // Extract the right state.
                    var oauthState = await AuthWebUtility.ExtracRedirectFromState(datastore, userId,
                        authorizationCode.State).ConfigureAwait(false);
    
                    return new RedirectResult(oauthState);
                }
            }
        }
