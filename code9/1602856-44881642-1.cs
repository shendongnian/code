    UserCredential credential;
          using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
          {
            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                // This OAuth 2.0 access scope allows for full read/write access to the
                // authenticated user's account.
                new[] { YouTubeService.Scope.Youtube },
                "user",
                CancellationToken.None,
                new FileDataStore(this.GetType().ToString())
            );
          }
