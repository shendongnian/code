            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "your_client_id",
                    ClientSecret = "your_client_secret_if_necessary"
                },
                Scopes = new [] { "scope_you_wish_to_access"}
            });
            var credential = new UserCredential(flow, "user_id", new TokenResponse
            {
                AccessToken = "user_access_token",
                RefreshToken = "user_refresh_token_if_necessary"
                // additional parameters if necessary
            });
            
            var service = new Any_Google_Service(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential
            });
