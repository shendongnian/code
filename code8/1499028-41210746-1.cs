    OdbcConnection conn = new OdbcConnection(connString);
    String strSQL = "INSERT INTO [TWEET_RESULT] ([SearchKeyword], [TweetID], [RetweetCount], [URL], [Body], [PostedTime], [Sentiment]) " +
                    "VALUES (?, ?, ?, ?, ?, ?, ?);"
    OdbcCommand cmd = new OdbcCommand(strSQL, conn);
    cmd.Parameters.Add("Search", OdbcType.Varchar).Value = "BVN";
    cmd.Parameters.Add("TweetID", OdbcType.Varchar).Value = "tag:search.twitter.com,2005:528481176659697664";
    cmd.Parameters.Add("Retweet", OdbcType.Varchar).Value = "1";
    cmd.Parameters.Add("URL", OdbcType.Varchar).Value = "http://twitter.com/austin_ebi/statuses/528481176659697664";
    cmd.Parameters.Add("Body", OdbcType.Varchar).Value = "Pls what is BVN going to be used for? Why can't every Nigerian just have 1 National Insurance number to be used for all purposes?";
    cmd.Parameters.Add("PostedTime", OdbcType.Varchar).Value = "2014-11-01T09:38:25.000Z";
    cmd.Parameters.Add("Sentiment", OdbcType.Varchar).Value = "NEUTRAL";
  
    try
    {
       conn.Open();
    
       Int affectedRows = cmd.ExecuteNonQuery();    
       Console.WriteLine("Affected Rows: {0}", affectedRows);
    }
    catch (Exception ex)
    {
       Console.WriteLine(ex.Message);
    }          
    
