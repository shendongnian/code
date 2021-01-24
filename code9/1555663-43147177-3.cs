    var matchingTweets = Search.SearchTweets(hashtag);
    
    //Grab the first 5 tweets from the results.
    var firstFiveTweets = matchingTweets.Take(5).ToList();
    //if you only want the ids and not the entire object
    var firstFiveTweetIds = matchingTweets.Take(5).Select(t => t.Id).ToList();
    
    //Iterate through and do stuff
    foreach (var tweet in matchingTweets)
    {
        //These are just examples of the properties accessible to you...
        if(tweet.Favorited)
        {
            var text = tweet.FullText;
        }     
        if(tweet.RetweetCount > 100)
        {
            //TODO: Handle popular tweets...
        }   
    }
    //Get item at specific index
    matchingTweets.ElementAt(index);
