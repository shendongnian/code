    using (var session = DocumentStoreHolder.Store.OpenSession())
    {
    	stream.TweetReceived += (sender, theTweet) =>
    	{
    		var tm = new TwitterModels
    		{
    			Id = theTweet.Tweet.Id,
    			TheTextFromTwitter = theTweet.Tweet.FullText
    		};
    
    		session.Store(tm);
    
    	};
    	stream.StartStream();
    	session.SaveChanges();	
    
    }
