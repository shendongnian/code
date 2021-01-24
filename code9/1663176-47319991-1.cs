            return true;
        }
        public override IHttpResult OnAuthenticated(IServiceBase authService,
            IAuthSession session, IAuthTokens tokens,
            Dictionary<string, string> authInfo)
        {
            var customUserSession = (CustomUserSession) session;
            //Fill IAuthSession with data you want to retrieve in the app eg:
            customUserSession.FirstName = "some_firstname_from_db";
            customUserSession.LastName = "some_lastname_from_db";
            customUserSession.Roles = new List<string> {"role1", "role2"};
            customUserSession.Permissions = new List<string> { "permission1", "permission2" };
            customUserSession.Email = "test@test.com";
            customUserSession.AuthProvider = "credentials";
            customUserSession.CreatedAt = DateTime.UtcNow;
            customUserSession.ZipCode = "92123";
            //Call base method to Save Session and fire Auth/Session callbacks:
            return base.OnAuthenticated(authService, session, tokens, authInfo);
        }
