      public static void SendTweet()
        {
            try
            {
                GetPixelImageFile();
                string key = ConfigurationSettings.AppSettings.Get("twitterConsumerKey");
                string secret = ConfigurationSettings.AppSettings.Get("twitterConsumerSecret");
                string token = ConfigurationSettings.AppSettings.Get("twitterAccessToken");
                string tokenSecret = ConfigurationSettings.AppSettings.Get("twitterAccessTokenSecret");
                string message = "Color, Colorful, Pixel, Art, PixelColouring, Follow";
                var service = new TweetSharp.TwitterService(key, secret);
                service.AuthenticateWith(token, tokenSecret);
                using (var stream = new FileStream(@"C:\Images\Pixel.png", FileMode.Open))
                {
                    var result = service.SendTweetWithMedia(new SendTweetWithMediaOptions
                    {
                        Status = message,
                        Images = new Dictionary<string, Stream> { { "john", stream } }
                    });
                    SendMail("SendTweet", (result == null ? "" : result.Text));
                }
            }
            catch (Exception ex)
            {
                SendMail("SendTweet", ex.Message);
            }
        }
