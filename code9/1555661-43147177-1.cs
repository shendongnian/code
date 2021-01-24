    var matchingTweets = Search.SearchTweets(hashtag);
    
    //Grab all Ids and put in a list
    matchingTweets.Select(t => t.Id).ToList();
    
    //Grab a specific tweet by Id
    var specificTweet = matchingTweets.FirstOrDefault(t => t.Id == 3652123654);
    
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
