        static public List<ITweet> GetTweets(string keyword)
        {
            RateLimit.RateLimitTrackerMode = RateLimitTrackerMode.TrackAndAwait;
            var searchParam = new Tweetinvi.Parameters.SearchTweetsParameters(keyword)
            {
                MaximumNumberOfResults = 1000
            };
            var tweets = Tweetinvi.Search.SearchTweets(searchParam).ToList();
            var tweetList = new List<ITweet>(tweets);
            while (tweets.Count > 0)
            {
                searchParam.MaxId = tweets.Select(x => x.Id).Min() - 1;
                searchParam.MaximumNumberOfResults = 5000;
                tweets = Tweetinvi.Search.SearchTweets(searchParam).ToList();
                tweetList.AddRange(tweets);
                Console.WriteLine($"Find : {tweets.Count}");
                Console.WriteLine($"All : {tweetList.Count}");
            }
            return tweetList;
        }
