    WebClient wc = new WebClient();
    // Downloading & Deserializing the Json file
    var jsonMain = wc.DownloadString("http://api.flexianalysis.com/services/FlexiAnalysisService.svc/FlexiAnalysisNews?key=gZ_lhbJ_46ThmvEki2lF&catagory=Forex");
    
    
    JObject token2 = JObject.Parse(jsonMain);
    JArray results = JArray.Parse(token2["d"].ToString());
    
    List<News> listNews = new List<News>();
    foreach (var result in results)
    {
    	news = new News();
    	news.id = (string)result["ID"];
    	news.Title = (string)result["Title"];
    	news.Date = (string)result["PublishingDate"];
    	news.Content = (string)result["News"];
    	listNews.Add(news);
    }
    
    return View(listNews);
