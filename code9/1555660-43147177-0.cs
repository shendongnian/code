    var matchingTweets = Search.SearchTweets(hashtag);
    //Grab all Ids and put in a list
    matchingTweets.Select(t => t.Id).ToList();
    //Iterate through and do stuff
    foreach (var tweet in matchingTweets)
    {
        //These are just examples of the properties accessible to you...
        if(tweet.Favorited)
        {
            var text = tweet.FullText;
        }        
    }
