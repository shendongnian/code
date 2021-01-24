           [HttpPost]
        public async Task<AppUser> Post([FromBody]GoogleSignInCredentials credentials)
        {
            // 1. get user id from idToken
            var oauthService = new Oauth2Service(new BaseClientService.Initializer { ApiKey = "{your api key}" });
            var tokenInfoRequest = oauthService.Tokeninfo();
            tokenInfoRequest.IdToken = credentials.IdToken;
            var userInfo = await tokenInfoRequest.ExecuteAsync();
            // 2. get access_token and refresh_token with new id and authorization code
            var tokenFromAuthorizationCode = await GetGoogleTokens(userInfo.UserId, credentials.AuthorizationCode);
            // 3. check if user exists
            var result = await _signInManager.ExternalLoginSignInAsync(
                "Google", userInfo.UserId, false);
            if (result.Succeeded)
                return await _userManager.FindByEmailAsync(userInfo.Email); 
            // 4. create user account
            var externalLoginInfo = new ExternalLoginInfo(
                ClaimsPrincipal.Current, "Google", userInfo.UserId, null);
          
            // 5. fetch user
            var createdUser = await SignInUser(externalLoginInfo, userInfo.Email);
            if (createdUser != null)
            {
                createdUser.GoogleAccessToken = tokenFromAuthorizationCode.AccessToken;
                createdUser.GoogleRefreshToken = tokenFromAuthorizationCode.RefreshToken;
                var updateResult = await _userManager.UpdateAsync(createdUser);
                if (updateResult.Succeeded)
                    return createdUser;
                return null;
            }
            return null;
        }
        private async Task<AppUser> SignInUser(ExternalLoginInfo info, string email)
        {
            var newUser = new AppUser { Email = email, UserName = email };
            var identResult = await _userManager.CreateAsync(newUser);
            if (identResult.Succeeded)
            {
                identResult = await _userManager.AddLoginAsync(newUser, info);
                if (identResult.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, false);
                    return await _userManager.FindByEmailAsync(email);
                }
            }
            return null;
        }
        private async Task<TokenResponse> GetGoogleTokens(string userId, string authorizationCode)
        {
            return await _authFlow.Flow.ExchangeCodeForTokenAsync(
                    userId, authorizationCode, "http://localhost:60473/signin-google", CancellationToken.None);
        }
