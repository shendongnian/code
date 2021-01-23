    appHost.Plugins.Add(new AuthFeature(() => new AuthUserSession(),
    new IAuthProvider[] {
        new GithubAuthProvider(appHost.AppSettings),
        //Use JWT so sessions survive across AppDomain restarts, redeployments, etc
        new JwtAuthProvider(appHost.AppSettings) 
        {
            CreatePayloadFilter = (payload, session) =>
            {
                var githubAuth = session.ProviderOAuthAccess.Safe()
                    .FirstOrDefault(x => x.Provider == "github");
                payload["ats"] = githubAuth != null 
                    ? githubAuth.AccessTokenSecret : null;
            },
            PopulateSessionFilter = (session, obj, req) => 
            {
                session.ProviderOAuthAccess = new List<IAuthTokens>
                {
                    new AuthTokens { Provider = "github", AccessTokenSecret = obj["ats"] }
                };
            } 
        },
    }));
