    using (var twitterCtx = new TwitterContext(auth))
    			{
    				var tweets =
    				await
    				(from tweet in twitterCtx.Status
    				 where tweet.Type == StatusType.Home
    				 && tweet.TweetMode == TweetMode.Extended
    				 select tweet)
    				.ToListAsync();
    
    				var filteredTweets = tweets.Where(t => t.Entities.HashTagEntities.Any(h => h.Tag == "GregsTestWall"));
    
    			}
