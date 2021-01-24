    private async Task Run()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    // This OAuth 2.0 access scope allows for read-only access to the authenticated 
                    // user's account, but not other types of account access.
                    new[] { YouTubeService.Scope.YoutubeReadonly },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(this.GetType().ToString())
                );
            }
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = this.GetType().ToString()
            });
            // var channelsListRequest = youtubeService.Channels.List("contentDetails");
            var playlistListRequest = youtubeService.Playlists.List("snippet");
            playlistListRequest.Mine = true;
            // Retrieve the contentDetails part of the channel resource for the authenticated user's channel.
            var playlistListResponse = await playlistListRequest.ExecuteAsync();
            foreach (var playlist in playlistListResponse.Items)
            {
                // From the API response, extract the playlist ID that identifies the list
                // of videos uploaded to the authenticated user's channel.
                var playlistListId = playlist.Id;
                Console.WriteLine("Videos in list {0}", playlistListId);
            }
        }
