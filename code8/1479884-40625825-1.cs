    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace WebApplication3.Services.ServiceAuthoriaztion.Impl
    {
        using System.Data.Entity.Core.Metadata.Edm;
        using System.IO;
        using System.Threading;
        using Google.Apis;
        using Google.Apis.Auth.OAuth2;
        using Google.Apis.Services;
        using Google.Apis.Util.Store;
        using Google.Apis.YouTube.v3;
    
    
        public class Youtube : ICustomService
        {
            private static YouTubeService _currentYouTubeService;
    
            public void Authorize()
            {
                UserCredential userCreds; 
                var filePath = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, @ "App_Data\client_id.json");
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    userCreds = GoogleWebAuthorizationBroker.AuthorizeAsync(
                     GoogleClientSecrets.Load(stream).Secrets,
                     new[] {
              YouTubeService.Scope.YoutubeReadonly
                     },
                     "user",
                     CancellationToken.None,
                     new FileDataStore("YouTubeData")
                    ).Result;
                }
                RefreshToken(userCreds);
    
                _currentYouTubeService = new YouTubeService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = userCreds,
                    ApplicationName = "DanilTestApp"
                });
    
                SerachTest();
    
            }
    
            private void SerachTest()
            {
                var searchListRequest = _currentYouTubeService.Search.List("snippet");
                searchListRequest.Q = "Google"; // Replace with your search term.
                searchListRequest.MaxResults = 50;
    
                // Call the search.list method to retrieve results matching the specified query term.
                var searchListResponse = searchListRequest.Execute();
    
                var asa = new List<string>();
    
            }
            //might not work, but something like this, got working code at home, office right now
            private void RefreshToken(UserCredential credential)
            {
                if (credential.Token.IsExpired(credential.Flow.Clock))
                {
                    if (credential.RefreshTokenAsync(CancellationToken.None).Result)
                    {
                        return;
                    }
                    else
                    {
                        throw;
                    }
                }
                return;
            }
    
        }
    }
