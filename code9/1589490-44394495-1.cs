    using (BulkInsertOperation bulkInsert = store.BulkInsert())
    {
       stream.TweetReceived += (sender, theTweet) =>
       {
           var tm = new TwitterModels
           {
               Id = theTweet.Tweet.Id,
               TheTextFromTwitter = theTweet.Tweet.FullText
           };
        
           bulkInsert.Store(tm);
       }
    };
