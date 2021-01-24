        static void PrintTweetsResults(List<Status> tweets)
        {
            if (tweets != null)
                tweets.ForEach(tweet => 
                {
                    if (tweet != null && tweet.User != null)
                        Console.WriteLine(
                            "ID: [{0}] Name: {1}\n\tTweet: {2}",
                            tweet.StatusID, tweet.User.ScreenNameResponse, tweet.Text);
                });
        }
