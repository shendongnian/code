    [WebMethod]
    public static List<ChartDetails> GetChartData()
    {
        // The rest of your code...
        foreach (var thisTweet in catTweets)
        {
            ChartDetails details = new ChartDetails();
            details.Category = thisTweet.Category;
            details.TweetCount = thisTweet.TweetCounts;
    
            dataList.Add(details);
        }
        return dataList;
    }
