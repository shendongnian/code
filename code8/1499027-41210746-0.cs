    string cmdStr = "INSERT INTO [TWEET_RESULT] ([SearchKeyword], [TweetID], [RetweetCount], [URL], [Body], [PostedTime], [Sentiment]) " +
                    "VALUES (@Search, @TweetID, @Retweet, @URL, @Body, @PostedTime, @Sentiment);"
    
    using (SqlConnection connection = new SqlConnection(ConnectionString))
    using (SqlCommand command = new SqlCommand(cmdStr, connection)) {
    
       command.Parameters.AddWithValue("@Search", "BVN");    
       command.Parameters.AddWithValue("@TweetID", "tag:search.twitter.com,2005:528481176659697664");    
       command.Parameters.AddWithValue("@Retweet", "1");
       command.Parameters.AddWithValue("@URL", "http://twitter.com/austin_ebi/statuses/528481176659697664");
       command.Parameters.AddWithValue("@Body", "Pls what is BVN going to be used for? Why can't every Nigerian just have 1 National Insurance number to be used for all purposes?");
       command.Parameters.AddWithValue("@PostedTime", "2014-11-01T09:38:25.000Z");
       command.Parameters.AddWithValue("@Sentiment", "NEUTRAL");
    
       try
       {
          connection.Open();
    
          int affectedRows = command.ExecuteNonQuery();    
          Console.WriteLine("Affected Rows: {0}", affectedRows);
       }
       catch (Exception ex)
       {
          Console.WriteLine(ex.Message);
       }          
    }
