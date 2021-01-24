    static void Main(string[] args)
	{
		Auth.SetUserCredentials() // redacted for SO
		var stream = Stream.CreateSampleStream();
		stream.TweetReceived += (sender, theTweet) =>
		{
			var tm = new TwitterModels
			{
				Id = theTweet.Tweet.Id,
				TheTextFromTwitter = theTweet.Tweet.FullText
			};
            using (var session = DocumentStoreHolder.Store.OpenSession())
            { 
			   session.Store(tm);
			   session.SaveChanges();
            }
		};
		stream.StartStream();             
	}       
