    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    using Google.Apis.YouTube.v3;
    using Google.Apis.YouTube.v3.Data;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace TestYoutube
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                Console.WriteLine("YouTube Data API: Playlist Updates");
                Console.WriteLine("==================================");
    
                try
                {
                    new Program().Run().Wait();
                }
                catch (AggregateException ex)
                {
                    foreach (var e in ex.InnerExceptions)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                }
    
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
    
            private async Task Run()
            {
                UserCredential credential;
                using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { YouTubeService.Scope.Youtube },
                        Environment.UserName,
                        CancellationToken.None,
                        new FileDataStore($"{Directory.GetCurrentDirectory()}/credentials")
                    );
                }
    
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = this.GetType().ToString()
                });
    
                // Create a new, private playlist in the authorized user's channel.
                var newPlaylist = new Playlist
                {
                    Snippet = new PlaylistSnippet
                    {
                        Title = "Test Playlist",
                        Description = "A playlist created with the YouTube API v3"
                    },
                    Status = new PlaylistStatus {PrivacyStatus = "public"}
                };
                newPlaylist = await youtubeService.Playlists.Insert(newPlaylist, "snippet,status").ExecuteAsync();
    
                // Add a video to the newly created playlist.
                var newPlaylistItem = new PlaylistItem
                {
                    Snippet = new PlaylistItemSnippet
                    {
                        PlaylistId = newPlaylist.Id,
                        ResourceId = new ResourceId
                        {
                            Kind = "youtube#video",
                            VideoId = "GNRMeaz6QRI"
                        }
                    }
                };
                newPlaylistItem = await youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").ExecuteAsync();
    
                Console.WriteLine("Playlist item id {0} was added to playlist id {1}.", newPlaylistItem.Id, newPlaylist.Id);
            }
        }
    }
