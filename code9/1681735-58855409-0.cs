    public async Task<IActionResult> ConfigureGA(CancellationToken cancellationToken)
            {
                GoogleAnalyticsModel model = new GoogleAnalyticsModel();
                var state = UriHelper.GetDisplayUrl(Request);
                var result = await GetCredential(state, cancellationToken);
                if (result.Credential != null)
                {
                    using (var svc = new AnalyticsService(
                        new BaseClientService.Initializer
                        {
                            HttpClientInitializer = result.Credential,
                            ApplicationName = "Your App Name"
                        }))
                    {
    
                        ManagementResource.AccountSummariesResource.ListRequest list = svc.Management.AccountSummaries.List();
                        list.MaxResults = 1000;
                        AccountSummaries feed = await list.ExecuteAsync();
                        model.UserAccounts = feed.Items.ToList();
                    }
    
                    return View(model);
                }
                else
                {
                    return new RedirectResult(result.RedirectUri);
                }
    
            }    
    private async Task<AuthorizationCodeWebApp.AuthResult> GetCredential(string state, CancellationToken cancellationToken)
            {
                var userId = userManager.GetUserAsync(User).Result.Id;
                var redirectUri = Request.Scheme + "://" + Request.Host.ToUriComponent() + "/authcallback/";
                using (var stream = new FileStream("client_secret.json",
                     FileMode.Open, FileAccess.Read))
                {
                    IAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                    {
                        ClientSecrets = GoogleClientSecrets.Load(stream).Secrets,
                        Scopes = new[] { AnalyticsService.Scope.AnalyticsReadonly, AnalyticsReportingService.Scope.AnalyticsReadonly },
                        DataStore = datastore
                    });
        
                    return await new AuthorizationCodeWebApp(flow, redirectUri, state)
                            .AuthorizeAsync(userId, cancellationToken);
                }
            }
